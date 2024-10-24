using BritInsuranceTestAutomation.Base;
using BritInsuranceTestAutomation.Helpers;
using BritInsuranceTestAutomation.Model;
using RestSharp;
using System.Text.Json;


namespace BritInsuranceTestAutomation.APITests
{
    public class ProductTests : BaseTest
    {

        [Test]
        public void AddAndEditProductWithAPI()
        {
            // Create New Product
            var Id = CreateNewProduct();
            Assert.IsNotNull(Id);

            // Edit New Product Name with Patch

            string updatedName = DataHelpers.GenerateRandomString(10);
            var result = EditProduct(Id, updatedName);
            Assert.Multiple(() =>
            {
                Assert.That(result.id, Is.EqualTo(Id));
                Assert.That(result.name, Is.EqualTo(updatedName));
            });
        }

        /// <summary>
        /// Create New Product using Post Request
        /// </summary>
        /// <returns></returns>
        public string? CreateNewProduct()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string jsonFilePath = Path.Combine(currentDirectory, $"TestData\\AddProduct.json");

            var client = new RestClient("https://api.restful-api.dev");
            var request = new RestRequest("/objects", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(File.ReadAllText(jsonFilePath));

            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return JsonSerializer.Deserialize<Product>(response.Content).id;
            else
                return null;
        }

        /// <summary>
        /// Edit Product Name using Patch request
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Product EditProduct(string id, string value)
        {
            var client = new RestClient("https://api.restful-api.dev");
            var request = new RestRequest("/objects/" + id + "", Method.Patch);
            request.AddHeader("Content-Type", "application/json");

            request.AddJsonBody(new { name = value });
            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var data = JsonSerializer.Deserialize<Product>(response.Content);
                return data;
            }
            else { return null; }

        }
    }
}
