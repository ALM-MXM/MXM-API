using System.Net;

namespace MXM_API.Extensions
{
    public static class GetClientIPAdress
    {

        public static string GetClientIPAddress(HttpContext httpContext)
        {

            string forwardedHeader = httpContext.Request.Headers["X-Forwarded-For"];
            if (!string.IsNullOrEmpty(forwardedHeader))
                return forwardedHeader.Split(',', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault()?.Trim();
            var clientAddresIp = httpContext.Connection.RemoteIpAddress.ToString();

            if (clientAddresIp.Trim() == "::1")
            {
                string hostName = Dns.GetHostName();
                IPHostEntry iPHostEntry = Dns.GetHostEntry(hostName);
                IPAddress[] arrIpAdress = iPHostEntry.AddressList;
                try
                {
                    foreach (IPAddress ipAddress in arrIpAdress)
                    {
                        if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            forwardedHeader = ipAddress.ToString();
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return forwardedHeader;
        }
    }
}
