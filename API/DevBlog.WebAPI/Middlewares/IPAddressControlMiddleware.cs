using System.Net;

namespace DevBlog.WebAPI.Middlewares
{
    public class IPAddressControlMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly IConfiguration _configuration;

        public IPAddressControlMiddleware(RequestDelegate requestDelegate, IConfiguration configuration)
        {
            _requestDelegate = requestDelegate;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            var ipAddressFromRequest = context.Connection.RemoteIpAddress;
            var ipAddressFromHosting = IPAddress.Parse(_configuration["AllowedAccess:WhiteIPAddress"]);
            //var ipAddressFromHosting = Dns.GetHostAddresses(new Uri(_configuration["AllowedAccess:WhiteIPAddress"]).Host)[0];
            if (ipAddressFromRequest!.Equals(ipAddressFromHosting))
            {
                await _requestDelegate.Invoke(context);
            }
            else
            {
                context.Response.Redirect(_configuration["AllowedAccess:RedirectAddress"]);
            }
        }
    }
}
