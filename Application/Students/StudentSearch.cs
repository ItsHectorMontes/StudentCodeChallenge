using Domain.Models;
using Infrastructure.SpStudent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Students
{
    /// <summary>    
    /// This class get all data of students but using parameters 
    /// Name or surname or Name of School,
    /// it have sent from insfractructure,
    /// then this class send it to controller.
    /// </summary>
    public class StudentSearch
    {
        public class Ejecuta : IRequest<List<StudentModel>>
        {
            public string Name { get; set; }
            
        }
        public class Handler : IRequestHandler<Ejecuta, List<StudentModel>>
        {
            private readonly IStudent _studentRepository;
            public Handler(IStudent studentRepository)
            {
                _studentRepository = studentRepository;
            }  
            public async Task<List<StudentModel>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var student = await _studentRepository.GetStudentsAsyncByParameters(request.Name);
                if (student == null)
                {
                    throw new Exception("Student Not Found.");
                }
                return student.ToList();
            }
        }
        


    }
}
