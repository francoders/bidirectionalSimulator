using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer.Comunicacion
{
    public class ServerSocket
    {
        private int puerto;
        private Socket servidor;
        private Socket comCliente;
        private StreamReader reader;
        private StreamWriter writer;

        public ServerSocket(int puerto)
        {
            this.puerto = puerto;
        }

        //Para levantar la conexion del server
        public bool Iniciar()
        {
            try
            {
                //1. Crear un Socket
                this.servidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //2. Tomar control del puerto
              //IPAddress.Parse("192.168.0.5");  
                this.servidor.Bind(new IPEndPoint(IPAddress.Any, this.puerto));
                //3. Definir cuantos clientes atenderé
                this.servidor.Listen(10);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //Para obtener cliente
        public bool ObtenerCliente()
        {
            try
            {
                this.comCliente = this.servidor.Accept();
                Stream stream = new NetworkStream(this.comCliente);
                this.writer = new StreamWriter(stream);
                this.reader = new StreamReader(stream);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //Pära mandar un mensaje al cliente (Writer)
        public bool Escribir(string mensaje)
        {
            try
            {
                this.writer.WriteLine(mensaje);
                this.writer.Flush();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //Para recibir un mensaje del cliente (Reader)
        public string Leer()
        {
            try
            {
                return this.reader.ReadLine().Trim();
            }
            catch (IOException ex)
            {

                return null;
            }
        }


        //Cerrar Conexion
        public void CerrarConexion()
        {
            this.comCliente.Close();
        }


    }
}
