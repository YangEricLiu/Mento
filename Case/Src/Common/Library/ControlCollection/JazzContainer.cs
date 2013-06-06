using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.TestApi.WebUserInterface.ControlCollection
{
    public sealed class JazzContainer : JazzControlCollection
    {

        #region Customer settings Containers

        #region Hierarchy property settings containers

        public static Container PeopleItemsContainer = GetControl<Container>(JazzControlLocatorKey.ContainerPeopleItems);
        #endregion

        #endregion

    }
}