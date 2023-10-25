using LaEzaDeliveryWebApi.Controllers.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace LaEzaDeliveryWebApi.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController
    {
        [HttpGet]
        public async Task <ActionResult<List<Mclientes>>> Get()
        {

        }
    }
}
