using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace WebApplication1.Filters
{
    public class NotImplExceptionFilterAttribute: ExceptionFilterAttribute
    {
        public object Request { get; private set; }

        public override void OnException(HttpActionExecutedContext context)
        {
            //if (context.Exception is NotImplementedException)
            //{
             //context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            //context.Response.Content.=context.Exception.Message;
            //context.Request.CreateResponse(HttpStatusCode.InternalServerError, "Please contact system administrator");
            //context.Request.CreateResponse(HttpStatusCode.InternalServerError, context.Exception.Message);
            //}

            var message = string.Format("Please contact system administrator");

            throw new HttpResponseException(context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message));
        
        //context.Exception.Message = new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
    }
    }
}