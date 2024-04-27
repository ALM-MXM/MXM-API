using System.Net;

namespace MXM_API.Extensions
{
    public static class GetClientIPAdress
    {

        public static string GetClientIPAddress(HttpContext httpContext)
        {
            try
            {
                string forwardedHeader = httpContext.Request.Headers["X-Forwarded-For"];
                if (!string.IsNullOrEmpty(forwardedHeader))
                {
                    return forwardedHeader.Split(',', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault()?.Trim();
                }
                else
                {                   
                    return httpContext.Connection.RemoteIpAddress?.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
    }
}
