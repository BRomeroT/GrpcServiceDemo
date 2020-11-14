using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace ConsoleClientGrpc
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            //using var channel = GrpcChannel.ForAddress("https://grpcservicedemo.azurewebsites.net/");

            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                new HelloRequest { Name = "Greeter Client Console" });
            Console.WriteLine($"Greeting: {reply.Message}");
            Console.ReadKey();

            var replyElements = await client.GetListAsync(new TotalElementsRequest { Elements = 20 });
            foreach (var item in replyElements.Items)
            {
                Console.WriteLine(item.Description);
            }
            Console.ReadLine();
        }
    }
}
