using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using DemoApiFramework.models;

namespace DemoApiFramework.validationTests;

public class GetCharacterValidetionTests
{
    private const string Endpoint = "/character";
    const string Host = "https://rickandmortyapi.com/api";
    
    [Test]
    public async Task GetCharacterTesting()
    {
        HttpClient _client = new HttpClient();
        HttpResponseMessage response = await _client.GetAsync(Host + Endpoint);
        string content = await response.Content.ReadAsStringAsync();
        JObject json = JObject.Parse(content);
        
        JSchema jShema = JSchema.Parse(File.ReadAllText(@"C:\git\TestProject\DemoApiFramework\DemoApiFramework\validationTests\GetCharactersPositive.json"));
        bool result = json.IsValid(jShema, out IList<string> messages);
        Assert.IsTrue(result, string.Join(" ,", messages.ToArray()));
        
    }
}
