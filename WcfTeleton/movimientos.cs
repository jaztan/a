using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WcfTeleton
{
    public class movimientos
    {

        public void LogServicioTeleton(String texto)
        {
            string fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            int Escrito = 0;
            do
            {
                try
                {
                    string fic = "C:\\ArchivoXMLHackathonTeleton\\log\\ServicioTeleton.txt";
                    FileInfo f = new FileInfo(fic);
                    if (((f.Length / 1024f) / 1024f) > 8)
                    {
                        f.CopyTo("C:\\ArchivoXMLHackathonTeleton\\log\\ServicioTeleton" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".txt");
                        //Console.WriteLine("Se copio archivo correctamente");
                        using (StreamWriter writer = File.CreateText("C:\\CT\\log\\ServicioTeleton.txt"))
                        {
                            writer.Write(DateTime.Now + texto);
                        }
                        Console.WriteLine("Se empieza nuevo archivo de log");
                    }
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(fic, true);
                    sw.WriteLine(DateTime.Now + " " + texto);
                    sw.Close();
                    Escrito = 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al escribir en LOG-MTV-SQL", ex.Message);
                    Escrito = 0;
                }
            } while (Escrito == 0);
        }
    }
}