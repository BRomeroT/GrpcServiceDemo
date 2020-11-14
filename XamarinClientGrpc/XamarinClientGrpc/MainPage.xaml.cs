using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using System.Net.Http;

namespace XamarinClientGrpc
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Appearing += async (s, e) =>
            {
                //using var channel = GrpcChannel.ForAddress("https://localhost:5001",
                using var channel = GrpcChannel.ForAddress("https://grpcservicedemo.azurewebsites.net/",
                    new GrpcChannelOptions { HttpClient = new HttpClient(new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler())) });
                var client = new Greeter.GreeterClient(channel);
                var reply = await client.SayHelloAsync(
                    new HelloRequest { Name = "Greeter Client Xamarin" });
                saludoLabel.Text = reply.Message;

                var replyElements = await client.GetListAsync(
                    new TotalElementsRequest { Elements = 500 });
                elements.ItemsSource = replyElements.Items.ToList();
            };
        }
    }
}
