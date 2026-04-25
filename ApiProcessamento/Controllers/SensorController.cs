using ApiProcessamento.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Shared;

namespace ApiProcessamento.Controllers
{
    [ApiController]
    [Route("api/v1/sensores")]
    public class SensorController : ControllerBase
    {
        private static List<SensorData> dados = new();
        private readonly IOptions<ApiConfig> _config;

        public SensorController(IOptions<ApiConfig> config)
        {
            _config = config;
        }

        [HttpPost]
        public IActionResult Receber(SensorData sensor)
        {
            if (sensor.Temperatura > _config.Value.MaxTemperatura)
            {
                return BadRequest("Temperatura acima do limite permitido!");
            }

            dados.Add(sensor);
            return Ok();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(dados);
        }
    }
}
