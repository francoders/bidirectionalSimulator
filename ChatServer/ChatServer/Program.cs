using ChatServer.Comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    class Program
    {
        static void Main(string[] args)
        {
            int puerto = Int32.Parse(ConfigurationManager.AppSettings["puerto"]);
            Console.WriteLine("Iniciando Servidor en puerto: {0}", puerto);
            ServerSocket servidor = new ServerSocket(puerto);
            if (servidor.Iniciar())
            {
                //Obtener cliente
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Esperando Cliente...");
                if (servidor.ObtenerCliente())
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Conexion Establecida!");
                    Console.WriteLine("S: Hola Mundo");
                    servidor.Escribir("Hola mundo cliente");
                    string mensaje = servidor.Leer();
                    Console.WriteLine("C:{0}", mensaje);
                    servidor.CerrarConexion();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No es posible Iniciar el Servidor");
                Console.ReadKey();
            }
        }
    }
}
