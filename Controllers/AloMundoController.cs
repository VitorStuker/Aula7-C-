using Microsoft.AspNetCore.Mvc;

namespace DemoWebServiceAloMundo.Controllers;

[ApiController]   //pré-configura comportamentos REST
[Route("api/[controller]")]    //atributos-anotações
public class AloMundoController : ControllerBase
{
    private readonly ILogger<AloMundoController> _logger;

    public AloMundoController(ILogger<AloMundoController> logger) //injeção de dependência do objeto logger
    {
        _logger = logger;
    }
    
    [HttpGet] //------>rota raiz
    public string Get()
    {
        _logger.LogInformation("AloMundoController.Get()");
        return "Alô mundo!"; //precisa ser serializada no body da resposta
    }

    [HttpGet("{nome}")] //------->/api/alomundo/qualquercoisa
    public string Get(string nome)
    {
        _logger.LogInformation($"AloMundoController.Get({nome})");
        return $"Alô mundo, {nome}!"; //precisa ser serializada no body da resposta
    }

    [HttpGet("query")]
    public string GetQuery(string nome)
    {
        _logger.LogInformation($"AloMundoController.GetQuery({nome})");
        return $"Alô Mundo, {nome}!";
    }

    [HttpPost]
    public string Post([FromBody] string nome) //body
    {
        _logger.LogInformation($"AloMundoController.Post({nome})");
        return $"Alô Mundo, {nome}!";
    }   

    [HttpPost("pessoa")]
    public string Post([FromBody] Pessoa pessoa) //body
    {
        _logger.LogInformation($"AloMundoController.Post({pessoa.Nome})");
        return $"Alô Mundo, {pessoa.Nome}!";
    }     
}
