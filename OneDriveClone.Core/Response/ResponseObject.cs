namespace OneDriveClone.Core.Response
{
    public class ResponseObject<T>
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
