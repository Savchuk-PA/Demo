using System.Net;
using DemoApiFramework.models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using RestSharp;

namespace DemoApiFramework;

public class NegativeGetPlanetsTests : TestBase
{
    private const string Endpoint = "/planets";

    [Test]
    [TestCase(7)]
    public void GetPlanetsByRestSharpNegativeTestTesting(int page)
    {
        var client = new RestClient();
        RestRequest request = new RestRequest(Host + Endpoint, Method.Get);
        request.AddParameter("page", page);
        RestResponse response = client.Execute(request);
        ResponsePlanet result = JsonConvert.DeserializeObject<ResponsePlanet>(response.Content);
        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode, "Ошибка ответа от api. Ожидаемый код ответа 404");
    }
}