using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StudentHouse.Controllers
{
    public class GetStudentsParameters
    {
        [FromQuery]
        public string Name { get; set; }

        [FromQuery]
        public string EMail { get; set; }

        [FromQuery]
        public string PhoneNumber { get; set; }
    }
}
