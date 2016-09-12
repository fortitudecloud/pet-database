using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Nancy;
using Nancy.ViewEngines;
using Nancy.ErrorHandling;

namespace PeoplePets
{

    /// <summary>
    /// Custom 404 handler for unknown routes
    /// </summary>
    public class NotFoundHandler : IStatusCodeHandler
    {
        private IViewRenderer viewRenderer;

        public NotFoundHandler(IViewRenderer viewRenderer)
        {
            this.viewRenderer = viewRenderer;
        }

        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            // Only applicable on 404
            return statusCode == HttpStatusCode.NotFound;
        }

        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            var response = viewRenderer.RenderView(context, "/404");
            response.StatusCode = statusCode;
            context.Response = response;
        }
    }
}