using Api.Admin.ViewModels;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace IntegrationTests.products
{
    public class AdminProductGroupTests
    {
        private string BaseGroupTypeUrl = "/api/v1/ProductGroupTypes";
        private const string BaseUrl = "/api/v1/ProductGroups";

        [Fact, Trait("Category", "ProductGroupIntegration")]
        public async void Add_ProductGroup_Action_Returns_Ok_When_Operation_IsSucceeded()
        {
            var serverBuilder = new TestServerBuilder<AdminStartup>();
            var client = serverBuilder.Client;

            // Arrange
            var groupTypeViewModel = CreateProductGroupTypeAddViewModel();
            var content = new StringContent(JsonConvert.SerializeObject(groupTypeViewModel), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(BaseGroupTypeUrl, content);
            response.EnsureSuccessStatusCode();

            var groupViewModel = CreateAddViewModel();
            content = new StringContent(JsonConvert.SerializeObject(groupViewModel), Encoding.UTF8, "application/json");

            // Act
            response = await client.PostAsync(BaseUrl, content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        private byte[] getIconBinary()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("SomeNamespace.somefile.png"))
            {
                string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.GetDirectories("Resources")[0].FullName;
                return File.ReadAllBytes($"{path}/favicon-194x194.png");
            }
        }

        private ProductGroupTypeAddViewModel CreateProductGroupTypeAddViewModel()
        {
            var icon = getIconBinary();
            return new ProductGroupTypeAddViewModel
            {
                Title = "ServiceADSL",
                IsActive = true,
                Icon = icon
            };
        }

        private ProductGroupAddViewModel CreateAddViewModel()
        {
            byte[] icon = getIconBinary();
            return new ProductGroupAddViewModel()
            {
                Title = "Test12",
                IsActive = true,
                ProductGroupTypeId = 1,
                Icon = icon,
                Provinces = new[] { 1 }
            };
        }
    }
}