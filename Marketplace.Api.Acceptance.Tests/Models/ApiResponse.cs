namespace Marketplace.Api.Acceptance.Tests.Models
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public dynamic Errors { get; set; }
    }
}
