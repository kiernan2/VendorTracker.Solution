using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace VendorTracker
{
  public class Program
  {
    public static void Main(static[] args)
    {
      IWebHost host = new WebHostBuilder()
        .UseKestrel()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseIISIntegration()
        .UseStartup<Startup>()
        .Build();

      host.Run();
    }
  }
}