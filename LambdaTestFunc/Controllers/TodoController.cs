using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LambdaTestFunc.Controllers
{
    [Route("api/Todo")]
    public class TodoController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {   
            return new string[] { "buy milk", "walk dog", "call mom", "wash car", "buy medicine", "wash hands", "brush teeth", "buy ticket", "call dad" };
        }

    }
}