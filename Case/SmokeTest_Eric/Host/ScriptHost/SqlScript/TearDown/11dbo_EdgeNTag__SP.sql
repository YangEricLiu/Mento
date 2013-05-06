/****** Object:  StoredProcedure [dbo].[ResetEdge]    Script Date: 03/27/2012 11:57:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ResetEdge]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ResetEdge]
GO


/****** Object:  StoredProcedure [dbo].[RemoveVertex]    Script Date: 03/27/2012 11:57:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RemoveVertex]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[RemoveVertex]
GO

/****** Object:  StoredProcedure [dbo].[RemoveEdge]    Script Date: 03/27/2012 11:57:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RemoveEdge]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[RemoveEdge]
GO

/****** Object:  StoredProcedure [dbo].[AddEdge]    Script Date: 03/27/2012 11:56:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddEdge]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AddEdge]
GO


/****** Object:  StoredProcedure [dbo].[AddEdge]    Script Date: 03/27/2012 11:47:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AddEdge]
   @StartVertexId bigint,
   @EndVertexId bigint,
   @Source varchar(150)
AS
BEGIN
   SET NOCOUNT ON

   IF EXISTS(SELECT Id 
   FROM Edge 
   WHERE StartVertex = @StartVertexId 
     AND EndVertex = @EndVertexId 
     AND Hops = 0)
   BEGIN
      RETURN 0 -- DO NOTHING!!!
   END

   IF @StartVertexId = @EndVertexId 
      OR EXISTS (SELECT Id 
                     FROM Edge 
                     WHERE StartVertex = @EndVertexId 
                       AND EndVertex = @StartVertexId)
   BEGIN
      RAISERROR ('Attempt to create a circular relation detected!', 21, 1) WITH SETERROR 
      RETURN -1
   END

   DECLARE @Id int

   INSERT INTO Edge (
         StartVertex,
         EndVertex,
         Hops,
         Source)
      VALUES (
         @StartVertexId,
         @EndVertexId,
         0,
         @Source)

   SELECT @Id = SCOPE_IDENTITY()
   UPDATE Edge
      SET EntryEdgeId = @Id
        , ExitEdgeId = @Id
        , DirectEdgeId = @Id 
      WHERE Id = @Id

   -- step 1: A's incoming edges to B
   INSERT INTO Edge (
         EntryEdgeId,
         DirectEdgeId,
         ExitEdgeId,
         StartVertex,
         EndVertex,
         Hops,
         Source) 
      SELECT Id
         , @Id
         , @Id
         , StartVertex 
         , @EndVertexId
         , Hops + 1
         , @Source
      FROM Edge
      WHERE EndVertex = @StartVertexId

   -- step 2: A to B's outgoing edges
   INSERT INTO Edge (
         EntryEdgeId,
         DirectEdgeId,
         ExitEdgeId,
         StartVertex,
         EndVertex,
         Hops,
         Source) 
      SELECT @Id
         , @Id
         , Id
         , @StartVertexId 
         , EndVertex
         , Hops + 1
         , @Source
      FROM Edge
      WHERE StartVertex = @EndVertexId

   -- step 3: A’s incoming edges to end vertex of B's outgoing edges
   INSERT INTO Edge (
         EntryEdgeId,
         DirectEdgeId,
         ExitEdgeId,
         StartVertex,
         EndVertex,
         Hops,
         Source)
      SELECT A.Id
         , @Id
         , B.Id
         , A.StartVertex 
         , B.EndVertex
         , A.Hops + B.Hops + 1
         , @Source
      FROM Edge A
         CROSS JOIN Edge B
      WHERE A.EndVertex = @StartVertexId
        AND B.StartVertex = @EndVertexId
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveEdge]    Script Date: 03/27/2012 11:47:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[RemoveEdge]
    @Id bigint
AS
BEGIN
    IF NOT EXISTS( SELECT Id FROM Edge WHERE Id = @Id AND Hops = 0 )
    BEGIN
        RAISERROR ('Relation does not exists', 21 ,1) WITH SETERROR 
        RETURN -1
    END

    CREATE TABLE #PurgeList (Id int)

    -- step 1: rows that were originally inserted with the first
    -- AddEdge call for this direct edge
    INSERT INTO #PurgeList
        SELECT Id
          FROM Edge
          WHERE DirectEdgeId = @Id

    -- step 2: scan and find all dependent rows that are inserted afterwards
    WHILE 1 = 1
    BEGIN
        INSERT INTO #PurgeList
            SELECT Id    
                FROM Edge
                WHERE Hops > 0
                    AND ( EntryEdgeId IN ( SELECT Id FROM #PurgeList ) 
                        OR ExitEdgeId IN ( SELECT Id FROM #PurgeList ) )
                AND Id NOT IN (SELECT Id FROM #PurgeList )
        IF @@ROWCOUNT = 0 BREAK
    END

    DELETE Edge
       WHERE Id IN ( SELECT Id FROM #PurgeList)
    DROP TABLE #PurgeList
END
GO
/****** Object:  StoredProcedure [dbo].[ResetEdge]    Script Date: 03/27/2012 11:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ResetEdge]
	@StartVertexId BIGINT,
	@NewVertexIdstr VARCHAR(4000),
	@Source VARCHAR(150),
	@Result INT=0 OUTPUT
AS
BEGIN
	SET NOCOUNT ON
	BEGIN TRY
		--GET NEW END VERTEX ID TABLE FROM @NewVertexIdstr
		DECLARE @EndVertexIdTb TABLE(Id BIGINT)
		DECLARE @Pos INT, @NextPos INT, @EndVertexId BIGINT
		SET @Pos = 0
		WHILE(@Pos <= LEN(@NewVertexIdstr))
		BEGIN
			SELECT @nextpos = CHARINDEX(',', @NewVertexIdstr, @Pos)
			IF (@NextPos = 0 OR @NextPos IS NULL)
				SELECT @nextpos = LEN(@NewVertexIdstr) + 1
			INSERT INTO @EndVertexIdTb VALUES(CAST(SUBSTRING(@NewVertexIdstr, @Pos, @NextPos - @Pos) AS BIGINT))
			SELECT @pos = @nextpos+1
		END
		
		--REMOVE OLD EDGE
		DECLARE @OldEdgeTb TABLE(Id BIGINT)
		DECLARE @EdgeId BIGINT
		
		INSERT INTO @OldEdgeTb SELECT Id FROM Edge WHERE EntryEdgeId=DirectEdgeId AND DirectEdgeId=ExitEdgeId AND StartVertex=@StartVertexId AND EndVertex NOT IN (SELECT Id FROM @EndVertexIdTb)
		
		DECLARE removecur CURSOR FOR SELECT Id FROM @OldEdgeTb
		OPEN removecur
		FETCH NEXT FROM removecur INTO @EdgeId
		WHILE @@FETCH_STATUS =0
		BEGIN
			EXEC RemoveEdge @EdgeId	
			FETCH NEXT FROM removecur INTO @EdgeId
		END
		CLOSE removecur
		DEALLOCATE removecur
			
		
		--ADD NEW EDGE
		IF(LTRIM(RTRIM(@NewVertexIdstr))<>'')
		BEGIN
			DECLARE addcur CURSOR FOR SELECT Id FROM @EndVertexIdTb 
			OPEN addcur
			FETCH NEXT FROM addcur INTO @EndVertexId
			WHILE @@FETCH_STATUS =0
			BEGIN
				EXEC AddEdge @StartVertexId,@EndVertexId,@Source
				FETCH NEXT FROM addcur INTO @EndVertexId
			END
			CLOSE addcur
			DEALLOCATE addcur
		END
		SET @Result=0
	END TRY
	BEGIN CATCH
		SET @Result=-1
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveVertex]    Script Date: 03/27/2012 11:47:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[RemoveVertex]
	@VertexId bigint
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @EdgeId BIGINT
	DECLARE removecur CURSOR FOR SELECT Id FROM Edge WHERE (StartVertex=@VertexId OR EndVertex=@VertexId) AND EntryEdgeId=DirectEdgeId AND DirectEdgeId=EntryEdgeId
	OPEN removecur
	FETCH NEXT FROM removecur INTO @EdgeId
	WHILE @@FETCH_STATUS =0
	BEGIN
		EXEC RemoveEdge @EdgeId	
		FETCH NEXT FROM removecur INTO @EdgeId
	END
	CLOSE removecur
	DEALLOCATE removecur
END
GO
