using System.Net;

namespace OneDriveClone.Core.Response
{
    public class Result<T>
    {
        private static ResponseObject<T> CreateObject(HttpStatusCode statusCode, string message, T? data = default)
        {
            return new ResponseObject<T>
            {
                StatusCode = (int)statusCode,
                Message = message,
                Data = data
            };
        }

        public static ResponseObject<T> Ok(string message, T? data = default)
        {
            return CreateObject(HttpStatusCode.OK, message, data);
        }

        public static ResponseObject<T> Created(string message, T? data = default)
        {
            return CreateObject(HttpStatusCode.Created, message, data);
        }

        public static ResponseObject<T> NoContent(string message)
        {
            return CreateObject(HttpStatusCode.NoContent, message);
        }

        public static ResponseObject<T> NotFound(string message)
        {
            return CreateObject(HttpStatusCode.NotFound, message);
        }

        public static ResponseObject<T> BadRequest(string message)
        {
            return CreateObject(HttpStatusCode.BadRequest, message);
        }
    }
}
