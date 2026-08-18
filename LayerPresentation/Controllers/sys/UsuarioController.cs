using ATIEnvioSMS.LayerData.Models.DTOs.sms;
using ATIEnvioSMS.LayerData.Models.DTOs.sys;
using ATIEnvioSMS.LayerLogic.Services.Interfaces.sys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ATIEnvioSMS.LayerPresentation.Controllers.sys
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioUseCases _usuarioServices;

        public UsuarioController(IUsuarioUseCases usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetAllUsuariosAsync(CancellationToken cancellationToken)
            => Ok(await _usuarioServices.ObtenerTodosLosUsuariosAsync(cancellationToken));

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactoDTO>> GetContactoByIDAsync(int id, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioServices.ObtenerUsuarioByIdAsync(id, cancellationToken);
            if (usuario == null) 
                return NotFound();
            return Ok(usuario);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<ActionResult> AddUsuarioAsync([FromBody] CreateUsuarioDTO UsuarioNew, CancellationToken cancellationToken)
        {
            if (UsuarioNew == null)
                return BadRequest("Usuario no puede estar vacio");

            try
            {
                await _usuarioServices.AgregarUsuarioAsync(UsuarioNew, cancellationToken);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUsuarioAsync(int id, [FromBody] UpdateUsuarioDTO UsuarioRequest, CancellationToken cancellationToken)
        {
            if (UsuarioRequest == null)
                return BadRequest("Modelo de Contacto no puede estar vacio");
            try
            {
                var Usuario = await _usuarioServices.ObtenerUsuarioByIdAsync(id, cancellationToken);
                if (Usuario is null)
                    return NotFound();

                await _usuarioServices.ActualizarUsuarioAsync(id, UsuarioRequest, cancellationToken);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //// DELETE api/<UsuarioController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
