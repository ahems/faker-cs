using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Faker;

namespace faker_functions
{
    public static class FakeAddressFunctions
    {
        [FunctionName("FakeStreetAddress")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            FakeAddress fakeAddress = new FakeAddress() {
                StreetAddress = Faker.Address.StreetAddress(),
                City = Faker.Address.City(),
                State = Faker.Address.UsState(),
                ZipCode = Faker.Address.ZipCode()
            };

            return new OkObjectResult(fakeAddress);
        }
    }
    public struct FakeAddress {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State  { get; set; }
        public string ZipCode  { get; set; }
    }
}
