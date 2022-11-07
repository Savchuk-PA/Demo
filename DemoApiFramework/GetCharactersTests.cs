using System.Net;
using System.Text.Json;
using DemoApiFramework.models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DemoApiFramework;

public class Tests : TestBase
{
    private HttpClient _client;
    private const string Endpoint = "/character";
    
    [OneTimeSetUp]
    public void BeforeClass()
    {
        _client = new HttpClient();
    }

    [SetUp]
    public void Setup()
    {
    }

   [Test]
    public async Task GetCharacterTesting()
    {
        HttpResponseMessage result = await _client.GetAsync(HostRick + Endpoint);
        
        string content = await result.Content.ReadAsStringAsync();
        JObject json = JObject.Parse(content);
        var status = result.StatusCode;
        
        Assert.That(status, Is.EqualTo(HttpStatusCode.OK), "Неверный код ответа от Api. Ожидаемый код 200");
        Assert.AreEqual("Summer Smith", json["results"][2]["name"].ToString());
        
        Console.WriteLine(json["results"][2]["name"]);
        
        
    }
}



