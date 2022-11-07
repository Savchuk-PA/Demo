using System.Net;
using System.Net.Http.Json;
using DemoApiFramework.models;

namespace TestProjectApi;

public class PostPetsTests
{
    
    private string Api = "https://petstore.swagger.io/v2/pet";

    [Test]
    public async Task PostPetsTesting()
    {
        HttpClient client = new HttpClient();
        Pets request = new Pets
        {
            Id = 5,
            Category = new Category
            {
                Id = 52,
                Name = "654"
            },
            Name = "0",
            PhotoUrls = new string[]
            {
                "sad",
                "sadasd"
            },
        };

        HttpResponseMessage result = await client.PostAsJsonAsync(Api, request);
        Console.WriteLine(await result.Content.ReadAsStringAsync());
        Assert.AreEqual(HttpStatusCode.OK, result.StatusCode, "Код ответа от апи не соответсвует ожидаемому");
    }
}