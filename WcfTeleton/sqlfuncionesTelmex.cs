using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfTeleton
{
    public class 
   sqlfuncionesTelmex
    {
        movimientos mtv = new movimientos();
    public string connectionString = "Data Source=localhost,1433;Initial Catalog=BDTeleton;Persist Security Info=False;User ID=glory;Password=glory110;";

    public string _showTelmex()
    {
        string Reg_SumaTelmex = "";
        try
        {
            SqlConnection conexion = new SqlConnection(connectionString);
            conexion.Open();
            string cadena = "SELECT sum(cast([Importe total Acumulado]as float)) as total from Telmex";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                Reg_SumaTelmex = registros["total"] + "";
            }
            conexion.Close();
            return Reg_SumaTelmex;
        }
        catch (Exception erc)
        {
            mtv.LogServicioTeleton("" + erc.Message);
            return Reg_SumaTelmex;
        }
    }
}
}