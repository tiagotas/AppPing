using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zeroconf;

namespace AppPing
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        //avc: denied { getattr }
        private void abrir(object sender, EventArgs e)
        {
            NetworkInterface card = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault();

            if (card != null)
            {
                GatewayIPAddressInformation address = card.GetIPProperties().GatewayAddresses.FirstOrDefault();

                if (address == null)
                    Console.WriteLine("Endereço Nulo");
                else
                    Console.WriteLine(address.Address);
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Dns.

            var IpAddress = Dns.GetHostAddresses(Dns.GetHostName()).FirstOrDefault();
            //var GatewayIpAddress = Dns.GetHostAddresses(Dns.get()).FirstOrDefault();

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


        /**
         * https://stackoverflow.com/questions/13634868/get-the-default-gateway
         */
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            IReadOnlyList<IZeroconfHost> responses = null;

            responses = await ZeroconfResolver.ResolveAsync("_http._tcp.local.");

            Console.WriteLine("Listando resultados...");
            Console.WriteLine("TOTAL = " + responses.Count());

            foreach (var resp in responses)
            {
                //if (resp.DisplayName == deviceHostName)
                //{
                    Console.WriteLine(resp.IPAddress);
                //}
            }




            /* var results = await ZeroconfResolver.ResolveAsync("_test._tcp.local.");

             Console.WriteLine("Listando resultados...");
             Console.WriteLine("TOTAL = " + results.Count());
             Console.WriteLine(results);

             foreach (IZeroconfHost resp in results)
                 Console.WriteLine(resp.IPAddress);*/

            //Console.WriteLine(results);

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
