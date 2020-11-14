using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServiceDemo
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override Task<ElementsReply> GetList(TotalElementsRequest request, ServerCallContext context)
        {
            var elements = new ElementsReply();
            for (int i = 1; i <= request.Elements; i++)
            {
                elements.Items.Add(new Element
                {
                    Number = i,
                    Description = $"Element {i}"
                }); ;
            }
            return Task.FromResult(elements);
        }
    }
}
