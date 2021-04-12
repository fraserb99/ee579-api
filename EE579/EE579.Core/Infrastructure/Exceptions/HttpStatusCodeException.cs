using System;

namespace EE579.Core.Infrastructure.Exceptions
{
    public class HttpStatusCodeException : Exception, IHttpStatusCodeException
    {
        public HttpStatusCodeException(int status)
        {
            Status = status;
        }

        public HttpStatusCodeException(int status, string body)
        {
            Status = status;
            Body = body;
        }

        public int Status { get; set; }
        public object Body { get; set; }

        public object RenderBody()
        {
            return RenderBodyCore();
        }

        protected virtual object RenderBodyCore()
        {
            if (Body != null) return Body;

            return null;
        }
    }
}
