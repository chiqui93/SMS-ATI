using ATIEnvioSMS.LayerData.Models.DTOs.sms;
using ATIEnvioSMS.LayerLogic.Services.Interfaces.sms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ATIEnvioSMS.LayerPresentation.Controllers.sms
{
    [Route("api/reg/[controller]")]
    [ApiController, Authorize]
    public class ContactoController : ControllerBase
    {
        private readonly IContactoUseCases _contactoServices;

        public ContactoController(IContactoUseCases contactoServices)
        {
            _contactoServices = contactoServices;
        }

        // GET: api/<ContactoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactoDTO>>> GetAllContactosAsync(CancellationToken cancellationToken)
            => Ok(await _contactoServices.ObtenerTodosContactosAsync(cancellationToken));

        // GET api/<ContactoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactoDTO>> GetContactoByIDAsync(int id, CancellationToken cancellationToken)
        {
            var Contacto = await _contactoServices.ObtenerContactoByIdAsync(id, cancellationToken);
            if (Contacto is null)
                return NotFound();
            return Ok(Contacto);
        }

        // POST api/<ContactoController>
        [HttpPost]
        public async Task<ActionResult> AddContactoAsync([FromBody] CreateContactoDTO ContactoNew, CancellationToken cancellationToken)
        {
            if (ContactoNew == null)
                return BadRequest("Modelo de Contacto no puede estar vacio");

            try
            {
                await _contactoServices.AgregarContactoAsync(ContactoNew, cancellationToken);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ContactoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateContactoAsync(int id, [FromBody] UpdateContactoDTO ContactoRequest, CancellationToken cancellationToken)
        {
            if (ContactoRequest == null)
                return BadRequest("Modelo de Contacto no puede estar vacio");
            try
            {
                var Contacto = await _contactoServices.ObtenerContactoByIdAsync(id, cancellationToken);
                if (Contacto is null)
                    return NotFound();

                await _contactoServices.ActualizarContactoAsync(id, ContactoRequest, cancellationToken);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
