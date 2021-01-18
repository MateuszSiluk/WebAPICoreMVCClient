using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{

    public class HomeController : ControllerBase
    {
        public string Index()
        {
            return "API Running...";
        }
    }
}
