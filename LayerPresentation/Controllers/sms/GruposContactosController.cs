using ATIEnvioSMS.LayerData.Models.DTOs.sms;
using ATIEnvioSMS.LayerLogic.Services.Interfaces.sms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ATIEnvioSMS.LayerPresentation.Controllers.sms
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class GruposContactosController : ControllerBase
    {
        private readonly IGrupoContactosUseCases _gruposContactoServices;

        public GruposContactosController(IGrupoContactosUseCases gruposContactoServices)
        {
            _gruposContactoServices = gruposContactoServices;
        }

        // GET: api/<GruposContactosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoContactoDTO>>> GetAllGruposContactosAsync(CancellationToken cancellationToken)
            => Ok(await _gruposContactoServices.ObtenerGruposDeContactosAsync(cancellationToken));

        // GET api/<GruposContactosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GruposContactosController>
        [HttpPost]
        public async Task<ActionResult> AddGrupoContactoAsync([FromBody] CreateGrupoContactosDTO grupoContactosNew, CancellationToken cancellationToken)
        {
            if (grupoContactosNew == null)
                return BadRequest("Modelo de Grupo de Contactos no puede estar vacio");

            try
            {
                await _gruposContactoServices.AgregarGrupoDeContactosAsync(grupoContactosNew, cancellationToken);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<GruposContactosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
