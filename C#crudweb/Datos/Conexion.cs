using System.Data.SqlClient;

namespace C_crudweb.Datos
{
    public class Conexion
    {
        private string CadenaSQL = string.Empty;

        public Conexion() { 
            
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            CadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }
    }
}
