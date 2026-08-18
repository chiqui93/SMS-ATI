using ATIEnvioSMS.LayerData.Models.DTOs.Security;
using ATIEnvioSMS.LayerLogic.Services.Interfaces.security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ATIEnvioSMS.LayerPresentation.Controllers.security
{
    [Route("api/security/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthUseCases _authServices;

        public AuthController(IAuthUseCases authServices)
        {
            _authServices = authServices;
        }

        // POST api/<AuthController>
        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponseDTO>> AutenticarUsuarioAsync([FromBody] AuthRequestDTO request, CancellationToken cancellationToken)
        {
            try
            {
                return await _authServices.AutenticarUsuarioAsync(request, cancellationToken);
            }
            catch (Exception)
            {
                return Unauthorized("Usuario no autorizado");
            }
        }

       
    }
}
