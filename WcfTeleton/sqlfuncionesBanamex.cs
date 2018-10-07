using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfTeleton
{
    public class sqlfuncionesBanamex
    {
        movimientos mtv = new movimientos();
        public string connectionString = "Data Source=localhost,1433;Initial Catalog=BDTeleton;Persist Security Info=False;User ID=glory;Password=glory110;";
        public string _showRegSucursal()
        {
            string RegSucursal = "";
            try
            {
                //id_cont = 0;
                SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
                string cadena = "SELECT DISTINCT [Sucursal] FROM[BDTeleton].[dbo].[FBanamex]";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registros = comando.ExecuteReader();
                while (registros.Read())
                {

                    RegSucursal += registros["Sucursal"] + ",";
                }
                conexion.Close();
                return RegSucursal;
            }
            catch (Exception erc)
            {
                mtv.LogServicioTeleton("Error en SELECT DISTINCT TIENDA FROM[BDTeleton].[dbo].[FBanamex]" + erc.Message);
                return RegSucursal;
            }
        }
        public string _showSumasucursal(string sucursal)
        {
            string Reg_Sumasucursal = "";
            try
            {
                SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
                string cadena = "  SELECT sum(CAST(Monto as float))as Monto from [BDTeleton].dbo.FBanamex where Sucursal='" + sucursal + "'";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registros = comando.ExecuteReader();
                while (registros.Read())
                {
                    Reg_Sumasucursal = registros["Monto"] + "";
                }
                conexion.Close();
                return Reg_Sumasucursal;
            }
            catch (Exception erc)
            {
                mtv.LogServicioTeleton("Error en   SELECT sum(CAST(Monto as float))as Monto from [BDTeleton].dbo.FBanamex where Sucursal='" + sucursal + "'" + erc.Message);
                return Reg_Sumasucursal;
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