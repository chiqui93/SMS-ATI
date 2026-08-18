using ATIEnvioSMS.LayerData.Models.DTOs.cod;
using ATIEnvioSMS.LayerLogic.Services.Interfaces.cod;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ATIEnvioSMS.LayerPresentation.Controllers.cod
{
    [Route("api/nom/[controller]")]
    [ApiController, Authorize]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaUseCases _empresaServices;

        public EmpresaController(IEmpresaUseCases empresaServices)
        {
            _empresaServices = empresaServices;
        }

        // GET: api/<EmpresaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaDTO>>> GetAllEmpresasAsync(CancellationToken cancellationToken)
            => Ok(await _empresaServices.ObtenerTodasEmpresasAsync(cancellationToken));

        // GET api/<EmpresaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpresaDTO>> GetEmpresaByIDAsync(int id, CancellationToken cancellationToken)
        {
            var empresa = await _empresaServices.ObtenerEmpresaByIdAsync(id, cancellationToken);
            if(empresa is null) 
                return NotFound();
            return Ok(empresa);
        }

        // POST api/<EmpresaController>
        [HttpPost]
        public async Task<ActionResult> AddEmpresaAsync([FromBody] CreateOrUpdateEmpresaDTO empresaNew, CancellationToken cancellationToken)
        {
            if (empresaNew == null) 
                return BadRequest("Modelo de empresa no puede estar vacio");

            try
            {
                await _empresaServices.AgregarEmpresaAsync(empresaNew, cancellationToken);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<EmpresaController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmpresaAsync(int id, [FromBody] CreateOrUpdateEmpresaDTO empresaRequest, CancellationToken cancellationToken)
        {
            if (empresaRequest == null)
                return BadRequest("Modelo de empresa no puede estar vacio");
            try
            {
                var empresa = await _empresaServices.ObtenerEmpresaByIdAsync(id, cancellationToken);
                if (empresa is null)
                    return NotFound();

                await _empresaServices.ActualizarEmpresaAsync(id, empresaRequest, cancellationToken);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
