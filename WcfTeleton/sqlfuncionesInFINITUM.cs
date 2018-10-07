using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfTeleton
{
    public class sqlfuncionesInFINITUM
    {
        movimientos mtv = new movimientos();
        public string connectionString = "Data Source=localhost,1433;Initial Catalog=BDTeleton;Persist Security Info=False;User ID=glory;Password=glory110;";

        public string _showInFINITUM()
        {
            string Reg_SumaInFINITUM = "";
            try
            {
                SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
                string cadena = "select Monto from Finfinitum  order by CONVERT(datetime, [FECHA_YHORA]) desc";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registros = comando.ExecuteReader();
                while (registros.Read())
                {
                    Reg_SumaInFINITUM += "" + registros["Monto"] + ",";
                }
                conexion.Close();
                return Reg_SumaInFINITUM;
            }
            catch (Exception erc)
            {
                mtv.LogServicioTeleton("" + erc.Message);
                return Reg_SumaInFINITUM;
            }
        }
    }
}