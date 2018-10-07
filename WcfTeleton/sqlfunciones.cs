using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfTeleton
{

    class sqlfunciones
    {
        movimientos mtv = new movimientos();
        public string connectionString = "Data Source=localhost,1433;Initial Catalog=BDTeleton;Persist Security Info=False;User ID=glory;Password=glory110;";
        public string _showRegioness()
        {
            string RegRecoleccion = "";
            try
            {
                //id_cont = 0;
                SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
                string cadena = "select DISTINCT region from BDTeleton.dbo.FarmaciasDelAhorro";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registros = comando.ExecuteReader();
                while (registros.Read())
                {

                    RegRecoleccion += registros["region"] + ",";
                }
                conexion.Close();
                return RegRecoleccion;
            }
            catch (Exception erc)
            {
                mtv.LogServicioTeleton("Error en SELECT * FROM Transaccion id_tipo_mvto=" + erc.Message);
                return RegRecoleccion;
            }
        }
        public string _showSucursalesxRegion(string region)
        {
            string RegSucursales = "";
            try
            {
                SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
                string cadena = "select DISTINCT  suc_nombre from BDTeleton.dbo.FarmaciasDelAhorro where region = '" + region + "'";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registros = comando.ExecuteReader();
                while (registros.Read())
                {
                    RegSucursales += registros["suc_nombre"] + ",";
                }
                conexion.Close();
                return RegSucursales;
            }
            catch (Exception erc)
            {
                mtv.LogServicioTeleton("Error en  select DISTINCT  suc_nombre from BDTeleton.dbo.FarmaciasDelAhorro where region = '" + region + "'" + erc.Message);
                return RegSucursales;
            }
        }
        public string _showHistorialdeMovimientosXsucursal(string sucursal)
        {
            string RegSucursales = "";
            try
            {
                SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
                string cadena = "select total from BDTeleton.dbo.FarmaciasDelAhorro where suc_nombre = '" + sucursal + "'  order by id desc";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registros = comando.ExecuteReader();
                while (registros.Read())
                {
                    RegSucursales += registros["total"] + ",";
                }
                conexion.Close();
                return RegSucursales;
            }
            catch (Exception erc)
            {
                mtv.LogServicioTeleton("Error en  select *from BDTeleton.dbo.FarmaciasDelAhorro where suc_nombre = " + sucursal + "'  order by id desc" + erc.Message);
                return "0,";
            }
        }
    }
}