using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BILL;

namespace DAL
{
    public class ubicaciones_DAL
    {
        SQLDBHelper oConexion;
        //inicia la conexion con la BD
        public ubicaciones_DAL() { 
             oConexion = new SQLDBHelper();
        }
        public bool Agregar(ubicaciones_BILL OubicacionesBILL) 
        {
         SqlCommand cmdComando = new SqlCommand();

            cmdComando.CommandText = "INSERT INTO Direcciones (Ubicacion, Latitud, Longitud) VALUES (@Ubicacion, @Latitud, @Longitud)"; 
            cmdComando.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = OubicacionesBILL.Ubicacion;
            cmdComando.Parameters.Add("@Latitud", SqlDbType.VarChar).Value = OubicacionesBILL.Latitud;
            cmdComando.Parameters.Add("@Longitud", SqlDbType.VarChar).Value = OubicacionesBILL.Longitud;

           return oConexion.EjecutarComandoSQL(cmdComando);
        }
        public bool Eliminar(ubicaciones_BILL oUbicacionesBLL)
        {
            SqlCommand cmdComando = new SqlCommand();

            cmdComando.CommandText = "DELETE FROM Direcciones WHERE ID = @ID";
            cmdComando.Parameters.Add("@ID", SqlDbType.Int).Value = oUbicacionesBLL.ID;

            return oConexion.EjecutarComandoSQL(cmdComando);

        }


        public bool Modificar(ubicaciones_BILL oUbicacionesBLL)
        {
            SqlCommand cmdComando = new SqlCommand();

            cmdComando.CommandText = "UPDATE Direcciones SET Ubicacion = @Ubicacion, Latitud = @Latitud, Longitud = @Longitud WHERE ID = @ID";
            cmdComando.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = oUbicacionesBLL.Ubicacion;
            cmdComando.Parameters.Add("@Latitud", SqlDbType.VarChar).Value = oUbicacionesBLL.Latitud;
            cmdComando.Parameters.Add("@Longitud", SqlDbType.VarChar).Value = oUbicacionesBLL.Longitud;

            cmdComando.Parameters.Add("@ID", SqlDbType.Int).Value = oUbicacionesBLL.ID;
            return oConexion.EjecutarComandoSQL(cmdComando);
        }

        //Seleccionar los registros de la tabla mediante un SELECT 
        public DataTable Listar()
        {
            SqlCommand cmdcomando = new SqlCommand();
            //Sentencia SQL para traer todos los registros de la tabla "Direcciones"
            cmdcomando.CommandText = "SELECT * FROM Direcciones";
            //Tipo de comando
            cmdcomando.CommandType = CommandType.Text;

            DataTable TablaResultante = oConexion.EjecutarSentenciaSQL(cmdcomando);

            return TablaResultante;



        }
    }
}
