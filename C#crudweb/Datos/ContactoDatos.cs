using System.Data.SqlClient;
using System.Data;
using C_crudweb.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public ContactoModelo ListarContacto(int IdContacto)
        {
            var objContacto=new ContactoModelo();
            var connect = new Conexion();
            using (var conexion = new SqlConnection(connect.getCadenaSQL())) {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_verContacto", conexion);
                cmd.Parameters.AddWithValue("IdContacto",IdContacto);
                cmd.CommandType=CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader()) {
                    while (dr.Read()) {
                        objContacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        objContacto.Nombre = dr["Nombre"].ToString();
                        objContacto.Telefono = dr["Telefono"].ToString();
                        objContacto.Correo = dr["Correo"].ToString();
                    }
                }
            }
            return objContacto;
        }

        public bool GuardarContacto(ContactoModelo objContacto)
        {
            bool respuesta;

            try
            {
                var connect = new Conexion();
                using (var conexion = new SqlConnection(connect.getCadenaSQL()))
                {
                    conexion.Open();    
                    SqlCommand cmd = new SqlCommand("sp_crearContacto", conexion);
                    cmd.Parameters.AddWithValue("Nombre",objContacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono",objContacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo",objContacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                respuesta = false;
            }
            return respuesta;
        }
    }
}
