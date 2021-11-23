using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class PersonPhoneController : Controller
    {
        private IPersonPhoneFacade _facade;
        private IPersonFacade _personfacade;
        private IPhoneNumberTypeFacade _phonetypefacade;

        public PersonPhoneController(IPersonPhoneFacade facade, IPersonFacade personfacade, IPhoneNumberTypeFacade phonetypefacade)
        {
            _facade = facade;
            _personfacade = personfacade;
            _phonetypefacade = phonetypefacade;
        }

        [HttpGet("get")]
        [ProducesResponseType(typeof(PersonPhoneListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var result = await _facade.FindAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro");
            }
        }

        [HttpGet("getbyid")]
        [ProducesResponseType(typeof(PersonPhone), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetByID(string phone)
        {
            try
            {
                var result = await _facade.GetByIdAsync(phone);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro");
            }
        }

        [HttpGet("getpersons")]
        [ProducesResponseType(typeof(PersonResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetPersons()
        {
            try
            {
                var result = await _personfacade.FindAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro");
            }
        }

        [HttpGet("getphonetypes")]
        [ProducesResponseType(typeof(PersonResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetPhoneTypes()
        {
            try
            {
                var result = await _phonetypefacade.FindAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro");
            }
        }

        [HttpPost("save")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> SaveAsync(PersonPhone personPhone)
        {
            try
            {
                await _facade.SaveAsync(personPhone);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro");
            }
        }

        [HttpPost("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteAsync(PersonPhone personPhone)
        {
            try
            {
                await _facade.DeleteAsync(personPhone);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro");
            }
        }
    }
}
