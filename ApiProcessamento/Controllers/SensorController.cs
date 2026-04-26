using ApiProcessamento.Data;
using ApiProcessamento.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace ApiProcessamento.Controllers
{
    [ApiController]
    [Route("api/v1/sensores")]
    public class SensorController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IOptions<ApiConfig> _config;

        public SensorController(AppDbContext context, IOptions<ApiConfig> config)
        {
            _context = context;
            _config = config;
        }

        /// <summary>
        /// POST api/v1/sensores: Recebe os dados do sensor e os armazena no banco de dados.
        /// </summary>
        /// <param name="sensor"></param>
        /// <returns></returns>
        /// <response code="200">Dados do sensor recebidos com sucesso.</response>
        /// <response code="400">Temperatura ou Pressão acima do limite permitido.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Receber(SensorData sensor)
        {
            if (sensor.Temperatura > _config.Value.MaxTemperatura || sensor.Pressao > _config.Value.MaxPressao)
            {
                return BadRequest("Temperatura ou Pressão acima do limite permitido!");
            }

            _context.Sensores.Add(sensor);
            await _context.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        /// GET api/v1/sensores: Retorna a lista de todos os dados dos sensores armazenados no banco de dados. 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var dados = await _context.Sensores.ToListAsync();
            return Ok(dados);
        }
    }
}
