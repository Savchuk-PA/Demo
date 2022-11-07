namespace DemoApiFramework;


public abstract class TestBase
{
    protected const string HostRick = "https://rickandmortyapi.com/api";
    protected const string Host = "https://swapi.dev/api/";
    protected const string HostUser = "http://users.bugred.ru/";
    protected string[] residentsTatoonie =
    {
        "https://swapi.dev/api/people/1/",
        "https://swapi.dev/api/people/2/",
        "https://swapi.dev/api/people/4/",
        "https://swapi.dev/api/people/6/",
        "https://swapi.dev/api/people/7/",
        "https://swapi.dev/api/people/8/",
        "https://swapi.dev/api/people/9/",
        "https://swapi.dev/api/people/11/",
        "https://swapi.dev/api/people/43/",
        "https://swapi.dev/api/people/62/"
    };

    protected string[] filmsTatoonie = 
    {
        "https://swapi.dev/api/films/1/",
        "https://swapi.dev/api/films/3/",
        "https://swapi.dev/api/films/4/",
        "https://swapi.dev/api/films/5/",
        "https://swapi.dev/api/films/6/" 
    };
    
    protected string[] residentsAlderaan =
    {
        "https://swapi.dev/api/people/5/",
        "https://swapi.dev/api/people/68/",
        "https://swapi.dev/api/people/81/"
    };

    protected string[] filmsAlderaan = 
    {
        "https://swapi.dev/api/films/1/",
        "https://swapi.dev/api/films/6/"
    };
}