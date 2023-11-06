using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCliente
{
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            TcpClient cliente = new TcpClient("127.0.0.1", 12345);
            Console.WriteLine("Conectado al servidor.");

            NetworkStream stream = cliente.GetStream();

            while (true)
            {
                Console.Write("Escribe un mensaje: ");
                string mensaje = Console.ReadLine();
                byte[] buffer = Encoding.ASCII.GetBytes(mensaje);
                stream.Write(buffer, 0, buffer.Length);

                byte[] respuestaBuffer = new byte[1024];
                int bytesRead = stream.Read(respuestaBuffer, 0, respuestaBuffer.Length);
                string respuesta = Encoding.ASCII.GetString(respuestaBuffer, 0, bytesRead);
                Console.WriteLine("Servidor dice: " + respuesta);
            }

            cliente.Close();
        }
    }
}
