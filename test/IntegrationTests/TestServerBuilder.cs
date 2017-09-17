using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.IO;
using System.Net.Http;

namespace IntegrationTests
{
    public class TestServerBuilder<TStartup> : IDisposable where TStartup : class
    {
        public TestServerBuilder()
        {
            var directory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent;

            var hostBuilder = WebHost.CreateDefaultBuilder().UseStartup<TStartup>().UseContentRoot(directory.FullName);

            Server = new TestServer(hostBuilder);
            Client = Server.CreateClient();
        }

        public HttpClient Client { get; }

        public TestServer Server { get; }

        public void Dispose()
        {
            Server?.Dispose();
        }

        private string GetDirtectoryPath(string projectname)
        {
            var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory());

            if (directoryInfo == null)
                throw new DirectoryNotFoundException($"Parent of {Directory.GetCurrentDirectory()} not found");

            var directory = $"{directoryInfo.Parent.Parent.Parent.Parent.FullName}\\src\\{projectname}";

            return directory;
        }
    }
}