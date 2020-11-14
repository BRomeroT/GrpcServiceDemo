using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServiceDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("GetList")]
        public ElementsReply GetList(int total)
        {
            var elements = new ElementsReply();
            for (int i = 1; i <= total; i++)
            {
                elements.Items.Add(new Element
                {
                    Number = i,
                    Description = $"Element {i}"
                }); ;
            }
            return elements;
        }
    }
}
