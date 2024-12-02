using System.Data.SqlClient;
using System.Data;
using C_crudweb.Models;

namespace C_crudweb.Datos
{
    public class ContactoDatos
    {
        public List<ContactoModelo> Listar()
        {
            var objVerContactos= new List<ContactoModelo>();
            var connect = new Conexion();
            using (var conexion= new SqlConnection(connect.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_mostrarContactos",conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        objVerContactos.Add(new ContactoModelo()
                        {
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString()
                        });
                    }
                }
            }
            return objVerContactos;
        }


    }
}
