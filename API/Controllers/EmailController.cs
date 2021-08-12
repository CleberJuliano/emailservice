using API.Dtos;
using API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase {
        private readonly IEmailServices emailServices;

        public EmailController(IEmailServices emailServices) {
            this.emailServices = emailServices;
        }

        /// <summary>
        /// Envia email para o destinaário.
        /// </summary>
        /// <response code="200">Email enviado com sucesso.</response>
        /// <response code="500">Erro no processamento da requisição.</response>      
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<StatusCodeResult> Enviar(EmailDto emailDto) {
            try {
                await emailServices.Enviar(emailDto);
                return StatusCode(200);
            } catch (Exception) {
                return StatusCode(500);
            }
        }
    }
}
