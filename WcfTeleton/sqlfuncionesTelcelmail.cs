using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfTeleton
{
    public class sqlfuncionesTelcelmail
    {
        movimientos mtv = new movimientos();
        public string connectionString = "Data Source=localhost,1433;Initial Catalog=BDTeleton;Persist Security Info=False;User ID=glory;Password=glory110;";
        public string _showRegTelcelmail()
        {
            string RegTelcelmail = "";
            try
            {
                //id_cont = 0;
                SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
                string cadena = "SELECT DISTINCT REGION FROM [BDTeleton].[dbo].[TelcelMail]";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registros = comando.ExecuteReader();
                while (registros.Read())
                {

                    RegTelcelmail += registros["REGION"] + ",";
                }
                conexion.Close();
                return RegTelcelmail;
            }
            catch (Exception erc)
            {
                mtv.LogServicioTeleton("Error en SELECT DISTINCT [REGION] FROM [BDTeleton].[dbo].[TelcelMail]" + erc.Message);
                return RegTelcelmail;
            }
        }
        public string _showTelcelmail(string sucursal)
        {
            string Reg_SumaTelcelmail = "";
            try
            {
                SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
                string cadena = "SELECT SUM(CAST(MONTO AS FLOAT)) AS MONTO FROM [BDTeleton].dbo.[TelcelMail]  where REGION='" + sucursal + "'";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registros = comando.ExecuteReader();
                while (registros.Read())
                {
                    Reg_SumaTelcelmail = registros["MONTO"] + "";
                }
                conexion.Close();
                return Reg_SumaTelcelmail;
            }
            catch (Exception erc)
            {
                mtv.LogServicioTeleton("SELECT SUM(CAST(MONTO AS FLOAT)) AS MONTO FROM [BDTeleton].dbo.[TelcelMail]  where REGION='" + sucursal + "'" + sucursal + "'" + erc.Message);
                return Reg_SumaTelcelmail;
            }
        }
    }
}