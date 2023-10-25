using LaEzaDeliveryWebApi.Conexion;
using LaEzaDeliveryWebApi.Controllers.Modelo;
using LaEzaDeliveryWebApi.Datos;
using System.Data;
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
        //Insertar un cliente
        public async Task InsertarCliente(Mclientes parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("INSERT INTO CLIENTES(nombreCliente, direccionCliente, correoCliente, telefonoCliente) " +
                    "VALUES (@nombreCliente, @direccionCliente, @correoCliente, @telefonoCliente)", sql))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nombreCliente", parametros.nombreCliente);
                    cmd.Parameters.AddWithValue("@direccionCliente", parametros.direccionCliente);
                    cmd.Parameters.AddWithValue("@correoCliente", parametros.correoCliente);
                    cmd.Parameters.AddWithValue("@telefonoCliente", parametros.telefonoCliente);

                    await sql.OpenAsync();
                    await cmd.ExecuteReaderAsync();
                }
            }
        }
    }
}
