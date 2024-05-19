using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Övningar_TCP
{
    public partial class ServerForm : Form
    {

        TcpListener lyssnare;
        TcpClient klient;
        int port = 12345;


        public ServerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lyssnare = new TcpListener(IPAdress.any, port);
            lyssnare.Start();

            klient = lyssnare.AcceptTcpClient();

            byte[] inData = new byte[256];

            int antalByte = klient.GetStream().Read(inData, 0, inData.Length);

            tbxInkorg.Text = Encoding.Unicode.GetString(inData, 0, antalByte);
            klient.Close();
            lyssnare.Stop();
        }
    }
}
