using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfTeleton
{
    public class sqlfuncionesSoriana
    {
        movimientos mtv = new movimientos();
        public string connectionString = "Data Source=localhost,1433;Initial Catalog=BDTeleton;Persist Security Info=False;User ID=glory;Password=glory110;";
        public string _showTiendas()
        {
            string RegTiendas = "";
            try
            {
                //id_cont = 0;
                SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
                string cadena = "SELECT DISTINCT TIENDA FROM[BDTeleton].[dbo].[FSoriana]";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registros = comando.ExecuteReader();
                while (registros.Read())
                {

                    RegTiendas += registros["TIENDA"] + ",";
                }
                conexion.Close();
                return RegTiendas;
            }
            catch (Exception erc)
            {
                mtv.LogServicioTeleton("Error en SELECT DISTINCT TIENDA FROM[BDTeleton].[dbo].[FSoriana]" + erc.Message);
                return RegTiendas;
            }
        }
        public string _showSxTienda(string TIENDA)
        {
            string Reg_showSxTienda = "";
            try
            {
                SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
                string cadena = "SELECT CONVERT(DATETIME, FECHA)as FECHAYHORA,TIENDA,DONADORES,IMPORTE FROM [BDTeleton].dbo.FSoriana WHERE TIENDA ='" + TIENDA + "' order by FECHAYHORA DESC";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registros = comando.ExecuteReader();
                while (registros.Read())
                {
                    Reg_showSxTienda += registros["IMPORTE"] + ",";
                }
                conexion.Close();
                return Reg_showSxTienda;
            }
            catch (Exception erc)
            {
                mtv.LogServicioTeleton("Error en  select DISTINCT  suc_nombre from BDTeleton.dbo.FarmaciasDelAhorro where region = '" + TIENDA + "'" + erc.Message);
                return Reg_showSxTienda;
            }
        }
        public string _showHistorialdeMovimientosXsucursal(string TIENDA)
        {
            string RegSucursales = "";
            try
            {
                SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
                string cadena = "SELECT CONVERT(DATETIME, FECHA) as FECHAYHORA,TIENDA,DONADORES,IMPORTE FROM[BDTeleton].dbo.FSoriana WHERE TIENDA = '" + TIENDA + "' order by FECHAYHORA DESC";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registros = comando.ExecuteReader();
                while (registros.Read())
                {
                    RegSucursales += registros["IMPORTE"] + ",";
                }
                conexion.Close();
                return RegSucursales;
            }
            catch (Exception erc)
            {
                mtv.LogServicioTeleton("Error en  select *from BDTeleton.dbo.FarmaciasDelAhorro where suc_nombre = " + TIENDA + "'  order by id desc" + erc.Message);
                return "0,";
            }
        }
    }
}