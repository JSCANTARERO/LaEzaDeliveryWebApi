using LaEzaDeliveryWebApi.Controllers.Modelo;
using LaEzaDeliveryWebApi.Datos;
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
            var funcion = new Dclientes();
            var lista = await funcion.Mostrarclientes();
            return lista;
        }
        [HttpPost]
        public async Task Post([FromBody] Mclientes parametros)
        {
            var funcion = new Dclientes();
            await funcion .InsertarCliente(parametros);
        }
    }
}
