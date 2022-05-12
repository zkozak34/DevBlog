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
            var ipAddressFromRequest = context.Connection.RemoteIpAddress.ToString();
            var ipAddressFromHosting = new List<string>();
            foreach (var s in _configuration["AllowedAccess:WhiteIPAddress"].Split(","))
            {
                ipAddressFromHosting.Add(s);
            }
            //var ipAddressFromHosting = Dns.GetHostAddresses(new Uri(_configuration["AllowedAccess:WhiteIPAddress"]).Host)[0];
            if (ipAddressFromHosting.Contains(ipAddressFromRequest))
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
