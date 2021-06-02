using Application.Students;
using Infrastructure.SpStudent;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Domain.Models;

namespace WebApi.Controllers
{
    
    public class StudentController : MyControllerBase
    {
        /// <summary>
        /// Task async to get students.
        /// http://localhost:5000/api/student/
        /// </summary>
        /// <returns>list of students.</returns>
        [HttpGet]
        public async Task<ActionResult<List<StudentModel>>> GetStudentsC()
        {
            return await Mediator.Send(new GetStudents.ListStudents());
        }
        /// <summary>
        /// Task async to get students by name or surname.}
        /// http://localhost:5000/api/student/hector
        /// </summary>
        /// <param name="name"></param>
        /// <returns>return a student .</returns>
        [HttpGet("{name}")]
        public async Task<ActionResult<List<StudentModel>>> GetStudentsByNameC(string name)
        {
            return await Mediator.Send(new StudentSearch.Ejecuta { Name = name });
        }

    }
}
