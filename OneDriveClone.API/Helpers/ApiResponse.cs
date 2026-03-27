using Microsoft.AspNetCore.Mvc;
using OneDriveClone.Core.Response;
using System.Text.Json;

namespace OneDriveClone.API.Helpers
{
    public class ApiResponse<T>(ResponseObject<T> responseObject) : IActionResult
    {
        ResponseObject<T> ResponseObject { get; set; } = responseObject;

        private readonly JsonSerializerOptions _jsonSerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;
            response.StatusCode = ResponseObject.StatusCode;
            if (ResponseObject.StatusCode == StatusCodes.Status204NoContent)
            {
                return;
            }

            response.ContentType = "application/json";

            var envelope = new
            {
                statusCode = ResponseObject.StatusCode,
                message = ResponseObject.Message,
                data = ResponseObject.Data
            };

            var json = JsonSerializer.Serialize(envelope, _jsonSerializerOptions);
            await response.WriteAsync(json);
        }
    }
}
