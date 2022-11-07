using System.Net;
using DemoApiFramework.models;
using Newtonsoft.Json;
using RestSharp;

namespace DemoApiFramework;

public class GetPlanetsRestSharpTest : TestBase
{
    private const string Endpoint = "/planets";
    
    [Test]
    [TestCase(1)] // кейс передает параметр страницы
    public void GetPlanetsByRestSharpTestTesting(int page) // передача номера страницы
    {
        var client = new RestClient();
        RestRequest request = new RestRequest(Host + Endpoint, Method.Get);
        request.AddParameter("page", page); // добавление параметра страницы
        RestResponse response = client.Execute(request);
        ResponsePlanet result = JsonConvert.DeserializeObject<ResponsePlanet>(response.Content);
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Ошибка ответа от api");
        
        Assert.Multiple(() =>
        {
            Assert.AreEqual(60, result.Count, "Общее количество планет не соотвестует ожидаемому результату. Ожидаемый результат 60");
            Assert.AreEqual("https://swapi.dev/api/planets/?page=2", result.Next, "Ссылка на следующую страницу не соотвествует ожидаемому результату. Ожидаемый результат https://swapi.dev/api/planets/?page=2");
            Assert.AreEqual(null, result.Previous, "Ссылка на передыдущую страницу не соотвествует ожидаемому результату. Ожидаемый результат Null");
            Assert.AreEqual("Tatooine", result.Results[0].Name ,"Имя планеты не соотвествует ожидаемому. Ожидаемое имя планеты Tatooine");
            Assert.AreEqual("23", result.Results[0].RotationPeriod, "Период вращения планеты не соотвествует ожидаемому. Ожидаемый период вращения планеты 23");
            Assert.AreEqual("304", result.Results[0].OrbitalPeriod, "Орбитальный период планеты не соотвествует ожидаемому. Ожидаемый период вращения планеты 304");
            Assert.AreEqual("10465", result.Results[0].Diameter, "Диаметр планеты не соотвествует ожидаемому. Ожидаемый диметр планеты 10465");
            Assert.AreEqual("arid", result.Results[0].Climate, "Климат планеты не соотвествует ожидаемому. Ожидаемый климат планеты arid");
            Assert.AreEqual("1 standard", result.Results[0].Gravity, "Гравитация  планеты не соотвествует ожидаемому. Ожидаемая гравитация планеты 1 standart");
            Assert.AreEqual("desert", result.Results[0].Terrain, "Местность планеты не соотвествует ожидаемому. Ожидаемая местность планеты desert");
            Assert.AreEqual("1", result.Results[0].SurfaceWater, "Вода на поверности  планеты не соотвествует ожидаемому. Ожидаемая вода на поверности планеты 1");
            Assert.AreEqual("200000", result.Results[0].Population, "Население планеты не соотвествует ожидаемому. Ожидаемое население планеты 200000");
            Assert.AreEqual(residentsTatoonie, result.Results[0].Residents, "Жители планеты не соотвествует ожидаемому реезультату");
            Assert.AreEqual(filmsTatoonie, result.Results[0].Films, "Фильмы о планете не соотвествуют ожидаемому результату");
            Assert.AreEqual("2014-12-09T13:50:49.641000Z", result.Results[0].Created, "Дата не соотвествует ожидаемому результату");
            Assert.AreEqual("2014-12-20T20:58:18.411000Z", result.Results[0].Edited, "Дата редактирования не соотвествует ожидаемому результату");
            Assert.AreEqual("https://swapi.dev/api/planets/1/", result.Results[0].Url, "Дата редактирования не соотвествует ожидаемому результату");

        });
        
        Assert.Multiple(() =>
        {
            Assert.AreEqual("Alderaan", result.Results[1].Name ,"Имя планеты не соотвествует ожидаемому. Ожидаемое имя планеты Alderaan");
            Assert.AreEqual("24", result.Results[1].RotationPeriod, "Период вращения планеты не соотвествует ожидаемому. Ожидаемый период вращения планеты 24");
            Assert.AreEqual("364", result.Results[1].OrbitalPeriod, "Орбитальный период планеты не соотвествует ожидаемому. Ожидаемый период вращения планеты 364");
            Assert.AreEqual("12500", result.Results[1].Diameter, "Диаметр планеты не соотвествует ожидаемому. Ожидаемый диметр планеты 12500");
            Assert.AreEqual("temperate", result.Results[1].Climate, "Климат планеты не соотвествует ожидаемому. Ожидаемый климат планеты temperate");
            Assert.AreEqual("1 standard", result.Results[1].Gravity, "Гравитация  планеты не соотвествует ожидаемому. Ожидаемая гравитация планеты 1 standart");
            Assert.AreEqual("grasslands, mountains", result.Results[1].Terrain, "Местность планеты не соотвествует ожидаемому. Ожидаемая местность планеты grasslands, mountains");
            Assert.AreEqual("40", result.Results[1].SurfaceWater, "Вода на поверности  планеты не соотвествует ожидаемому. Ожидаемая вода на поверности планеты 40");
            Assert.AreEqual("2000000000", result.Results[1].Population, "Население планеты не соотвествует ожидаемому. Ожидаемое население планеты 2000000000");
            Assert.AreEqual(residentsAlderaan, result.Results[1].Residents, "Жители планеты не соотвествует ожидаемому реезультату");
            Assert.AreEqual(filmsAlderaan, result.Results[1].Films, "Фильмы о планете не соотвествуют ожидаемому результату");
            Assert.AreEqual("2014-12-10T11:35:48.479000Z", result.Results[1].Created, "Дата не соотвествует ожидаемому результату");
            Assert.AreEqual("2014-12-20T20:58:18.420000Z", result.Results[1].Edited, "Дата редактирования не соотвествует ожидаемому результату");
            Assert.AreEqual("https://swapi.dev/api/planets/2/", result.Results[1].Url, "Дата редактирования не соотвествует ожидаемому результату");
            
        });
    }
    
}