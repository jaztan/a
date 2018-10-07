using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfTeleton
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        sqlfunciones sql = new sqlfunciones();
        sqlfuncionesTelmex telmex = new sqlfuncionesTelmex();
        sqlfuncionesInFINITUM INFINITUM = new sqlfuncionesInFINITUM();
        sqlfuncionestelecomm telcomm = new sqlfuncionestelecomm();
        sqlfuncionesTelcelmail telcel = new sqlfuncionesTelcelmail();
        sqlfuncionesBanamex banamex = new sqlfuncionesBanamex();
        sqlfuncionesSoriana sor = new sqlfuncionesSoriana();
        public Double MostrarTotalTeleton()
        {
            Double Total = 0;
            var ValRegiones88 = sql._showRegioness().ToString().Split(',');
            var IntRegiones88 = ValRegiones88.Length;
            for (int x = 0; x < IntRegiones88; x++)
            {
                if (ValRegiones88[x].Length > 2)
                {
                    var SucursalesxRegion88 = sql._showSucursalesxRegion(ValRegiones88[x]).ToString().Split(',');
                    var IntSucursales88 = SucursalesxRegion88.Length;
                    for (int x1 = 0; x1 < IntSucursales88; x1++)
                    {
                        if (SucursalesxRegion88[x1].Length > 2)
                        {
                            var MontoxSucursal88 = sql._showHistorialdeMovimientosXsucursal(SucursalesxRegion88[x1]).ToString().Split(',');
                            Total += Convert.ToDouble(MontoxSucursal88[0]);
                        }
                    }
                }
            }

            Double Total2 = 0;
            var ValTiendas33 = sor._showTiendas().ToString().Split(',');
            var IntTiendas33 = ValTiendas33.Length;
            for (int x = 0; x < IntTiendas33; x++)
            {
                if (ValTiendas33[x].Length > 2)
                {
                    var SucursalesxTienda33 = sor._showHistorialdeMovimientosXsucursal(ValTiendas33[x]).ToString().Split(',');

                    Total2 += Convert.ToDouble(SucursalesxTienda33[0]);
                }
            }

            Double Total33 = 0;
            var ValSucursal22 = banamex._showRegSucursal().ToString().Split(',');
            var IntSucursal22 = ValSucursal22.Length;
            for (int x = 0; x < IntSucursal22; x++)
            {
                if (ValSucursal22[x].Length > 2)
                {
                    var SucursalesxTienda22 = banamex._showSumasucursal(ValSucursal22[x]).ToString().Split(',');

                    Total33 += Convert.ToDouble(SucursalesxTienda22[0]);
                }
            }
            Double Total3 = (Total33 / 100);
            Double Total4 = 0;
            var ValSucursal11 = telcel._showRegTelcelmail().ToString().Split(',');
            var IntSucursal11 = ValSucursal11.Length;
            for (int x = 0; x < IntSucursal11; x++)
            {
                if (ValSucursal11[x].Length > 2)
                {
                    var SucursalesxTelcel11 = telcel._showTelcelmail(ValSucursal11[x]).ToString();

                    Total4 += Convert.ToDouble(SucursalesxTelcel11);
                }
            }

            Double Total6 = 0;
            //var ValSucursal = telcomm._showRegtelecomm().ToString().Split(',');
            //var IntSucursal = ValSucursal.Length;
            //for (int x = 0; x < IntSucursal; x++)
            //{
            //    if (ValSucursal[x].Length >=1)
            //    {
            var SucursalesxTelcel = INFINITUM._showInFINITUM().ToString().Split(',');

            var Total9 = SucursalesxTelcel[0].ToString().Split('$');
            //    }
            //}

            Double Total5 = 0;
            var ValSucursal00 = telcomm._showRegtelecomm().ToString().Split(',');
            var IntSucursal00 = ValSucursal00.Length;
            for (int x = 0; x < IntSucursal00; x++)
            {
                if (ValSucursal00[x].Length >= 1)
                {
                    var SucursalesxTelcel00 = telcomm._showRegtelecomm(ValSucursal00[x]).ToString();

                    Total5 += Convert.ToDouble(SucursalesxTelcel00);
                }
            }

            var ValorTelmex = telmex._showTelmex();
            var Suma = Total + Total2 + Total3 + Total4 + Total6 + Total5 + Convert.ToDouble(ValorTelmex);
            return Suma;
        }
    }
}
