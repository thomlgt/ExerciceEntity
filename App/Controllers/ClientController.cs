using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.Services;
using App.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Route("clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClientService service;

        public ClientController(IClientService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Insert(Client client)
        {
            this.service.AjouterClient(client);
            return Ok();
        }
    }
}