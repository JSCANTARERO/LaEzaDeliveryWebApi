using LaEzaDeliveryWebApi.Conexion;
using LaEzaDeliveryWebApi.Controllers.Modelo;
using LaEzaDeliveryWebApi.Datos;
using System.Data.SqlClient;

namespace LaEzaDeliveryWebApi.Datos

{
    public class Dclientes
    {
        ConexionDB cn = new ConexionDB();
        //Retornar una lista de clientes
        public async Task<List<Mclientes>> Mostrarclientes()
        {
            var lista = new List<Mclientes>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SELECT * FROM CLIENTES", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.Text;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while(await item.ReadAsync())
                        {
                            var mclientes = new Mclientes();
                            mclientes.idCliente = (int)item["idCliente"];
                            mclientes.nombreCliente = (string)item["nombreCliente"];
                            mclientes.direccionCliente = (string)item["direccionCliente"];
                            mclientes.correoCliente = (string)item["correoCliente"];
                            mclientes.telefonoCliente = (string)item["telefonoCliente"];
                            lista.Add(mclientes);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
