using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfTeleton
{
    public class sqlfuncionestelecomm
    {
        movimientos mtv = new movimientos();
        public string connectionString = "Data Source=localhost,1433;Initial Catalog=BDTeleton;Persist Security Info=False;User ID=glory;Password=glory110;";
        public string _showRegtelecomm()
        {
            string Regtelecomm = "";
            try
            {
                //id_cont = 0;
                SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
                string cadena = " select DISTINCT Estado from FTelecom";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registros = comando.ExecuteReader();
                while (registros.Read())
                {

                    Regtelecomm += registros["Estado"] + ",";
                }
                conexion.Close();
                return Regtelecomm;
            }
            catch (Exception erc)
            {
                mtv.LogServicioTeleton("Error en SELECT DISTINCT [REGION] FROM [BDTeleton].[dbo].[TelcelMail]" + erc.Message);
                return Regtelecomm;
            }
        }
        public string _showRegtelecomm(string estado)
        {
            string Reg_SumaTelcelmail = "";
            try
            {
                SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
                string cadena = "select SUM(Monto) as Monto from FTelecom where Estado='" + estado + "'";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registros = comando.ExecuteReader();
                while (registros.Read())
                {
                    Reg_SumaTelcelmail = registros["Monto"] + "";
                }
                conexion.Close();
                return Reg_SumaTelcelmail;
            }
            catch (Exception erc)
            {
                mtv.LogServicioTeleton("SELECT SUM(CAST(MONTO AS FLOAT)) AS MONTO FROM [BDTeleton].dbo.[TelcelMail]  where REGION='" + estado + "'" + "'" + erc.Message);
                return Reg_SumaTelcelmail;
            }
        }
    }
}