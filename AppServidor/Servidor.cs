using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppServidor
{
    public partial class Servidor : Form
    {
        public Servidor()
        {
            InitializeComponent();
        }

        private void botonServidor_Click(object sender, EventArgs e)
        {
            TcpListener servidor = new TcpListener(IPAddress.Parse("127.0.0.1"), 12345);
            servidor.Start();
            Console.WriteLine("Servidor en ejecución. Esperando conexiones...");

            while (true)
            {
                TcpClient cliente = servidor.AcceptTcpClient();
                Console.WriteLine("Cliente conectado.");

                NetworkStream stream = cliente.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string mensaje = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Cliente dice: " + mensaje);

                    // Aquí puedes agregar la lógica del servidor para responder al cliente.
                    // Por ejemplo, puedes enviar un mensaje de vuelta al cliente.

                    byte[] respuesta = Encoding.ASCII.GetBytes("Servidor responde: Hola, cliente.");
                    stream.Write(respuesta, 0, respuesta.Length);
                }

                cliente.Close();
                Console.WriteLine("Cliente desconectado.");
            }
        }
    }
}
