using System;
using Microsoft.AspNetCore.Mvc;

namespace StudentHouse.Controllers
{
    public class GetStudentByIdParameters
    {
        [FromRoute]
        public Guid StudentId { get; set; }
    }
}
