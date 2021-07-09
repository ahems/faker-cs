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
    public static class FakePersonFunctions
    {
        [FunctionName("FakePerson")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            FakePerson fakePerson = new FakePerson() {
                FirstName = Faker.Name.First(),
                MiddleName = Faker.Name.Middle(),
                LastName = Faker.Name.Last(),
                Prefix = Faker.Name.Prefix(),
                Suffix = Faker.Name.Suffix(),
                DateOfBirth = Faker.Identification.DateOfBirth(),
                PhoneNumber = Faker.Phone.Number(),
                CompanyName = Faker.Company.Name(),
                CatchPhrase = Faker.Company.CatchPhrase(),
                Slogan = Faker.Company.BS(),
                AboutMe = Faker.Lorem.Paragraph(5),
                Email = Faker.Internet.FreeEmail(),
                UserName = Faker.Internet.UserName(),
                Url = Faker.Internet.Url()
            };

            return new OkObjectResult(fakePerson);
        }
    }
    public struct FakePerson {
        public DateTime DateOfBirth  { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public string CompanyName { get; set; }
        public string AboutMe { get; set; }
        public string CatchPhrase { get; set; }
        public string Slogan { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName  { get; set; }
        public string Url  { get; set; }
    }
}
