using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppPing
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var IpAddress = Dns.GetHostAddresses(Dns.GetHostName()).FirstOrDefault();

            if (IpAddress != null)
                txt_ip.Text = IpAddress.ToString();

            //txt_ip_gateway.Text = GetDefaultGateway().ToString();

            //IPAddress teste = GetDefaultGateway();

            //if(teste != null)
            //  Console.WriteLine(teste.ToString());

            var teste = NetworkInterface
                        .GetAllNetworkInterfaces()[0]
                        .GetIPProperties()
                        .GatewayAddresses
                        .FirstOrDefault();

            Console.WriteLine("IP DO GATEWAY = " + teste);

        }

       /* public static IPAddress GetDefaultGateway()
        {
            return NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault();


            /*return NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up)
                .Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .SelectMany(n => n.GetIPProperties()?.GatewayAddresses)
                .Select(g => g?.Address)
                .Where(a => a != null)
                // .Where(a => a.AddressFamily == AddressFamily.InterNetwork)
                // .Where(a => Array.FindIndex(a.GetAddressBytes(), b => b != 0) >= 0)
                .FirstOrDefault();*/
        //}
    }
}
