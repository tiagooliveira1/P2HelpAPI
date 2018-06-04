using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2HelpAPICore.Models;
using System.Net;

namespace P2HelpAPICore.Controllers
{
    [Produces("application/json")]
    [Route("api/Cep")]
    public class CepController : Controller
    {
        private readonly P2HelpContext _context;

        public CepController(P2HelpContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCep([FromRoute] int id)
        {
            WebClient wc = new WebClient();
            wc.OpenReadCompleted += (o, a) =>
            {
                /*if (callback != null)
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Response));
                    callback(ser.ReadObject(a.Result) as Response);
                }*/
            };
            //wc.OpenReadAsync(uri);

            return Ok();
        }
    }
}