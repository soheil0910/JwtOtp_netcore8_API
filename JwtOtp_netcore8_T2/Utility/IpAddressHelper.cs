namespace JwtOtp_netcore8_T2.Utility
{
    public class IpAddressHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        // Constructor to inject IHttpContextAccessor
        public IpAddressHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // Method to get the client IP address
        public string GetClientIpAddress()
        {
            var context = _httpContextAccessor.HttpContext;

            // First, try to get the IP from the X-Forwarded-For header (in case of proxies)
            var ipAddress = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();

            // If no X-Forwarded-For header is present, use RemoteIpAddress
            if (string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = context.Connection.RemoteIpAddress?.ToString();
            }

            return ipAddress;
        }

    }
}
