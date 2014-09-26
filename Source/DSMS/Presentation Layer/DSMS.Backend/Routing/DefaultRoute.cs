// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRoute.cs" company="">
//   Copyright � 2014 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace App.DSMS.Backend.Routing
{
    using System.Web.Routing;

    public class DefaultRoute : Route
    {
        public DefaultRoute()
            : base("{*path}", new DefaultRouteHandler())
        {
            this.RouteExistingFiles = false;
        }
    }
}
