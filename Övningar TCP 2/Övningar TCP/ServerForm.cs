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
            try
            {
                lyssnare = new TcpListener(IPAdress.any, port);
                lyssnare.Start();

            }
            catch (Exception error) { MessageBox.Show(error.Message, Text}; return; }

            btnStartServer.Enable = false;
            StartaMottagning();

        }

        public async void StartaMottagning()
    {
        try
        {
            klient = await lyssnare.AcceptTcpClientAsync();
        }
        catch ( Exception error) { MessageBox.Show(error.Message, Text); return; }

        StartaLäsning(klient);
    }

    public async void StartaLäsning ( TcpClient k)
    {
        byte[] buffert = new byte[1024];


        int n = 0;
        try
        {
            n = await k.GetStream().ReadAsync(buffert, 0, buffert.Lenght);
        }
        catch (Exception error) { MessageBox.Show(error.Message, Text); return; }

        tbxInkorg.AppnedText(Encoding.Unicode.GetString(buffert, 0, n));

        StartaLäsning(k);
    }
    
}
