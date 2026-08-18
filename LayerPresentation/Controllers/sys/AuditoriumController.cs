using ATIEnvioSMS.LayerData.Models.DTOs.sys;
using ATIEnvioSMS.LayerLogic.Services.Interfaces.sys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ATIEnvioSMS.LayerPresentation.Controllers.sys
{
    [Route("api/sys/[controller]")]
    [ApiController, Authorize]
    public class AuditoriumController : ControllerBase
    {
        private readonly IAuditoriumUseCases _logServices;

        public AuditoriumController(IAuditoriumUseCases logServices)
        {
            _logServices = logServices;
        }

        // GET: api/<LogsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuditoriumDTO>>> GetAllLogsAsync(CancellationToken cancellationToken)
            => Ok(await _logServices.ObtenerTodosLosLogAsync(cancellationToken));
    }
}
