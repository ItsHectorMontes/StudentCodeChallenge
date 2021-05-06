using Domain.Models;
using Infrastructure.SpStudent;
using MediatR;
using System;
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
        public class Ejecuta : IRequest<StudentModel>
        {
            public string Name { get; set; }
            
        }
        public class Handler : IRequestHandler<Ejecuta, StudentModel>
        {
            private readonly IStudent _studentRepository;
            public Handler(IStudent studentRepository)
            {
                _studentRepository = studentRepository;
            }         

            public async Task<StudentModel> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var student = await _studentRepository.GetStudentsAsyncByParameters(request.Name);
                if (student == null)
                {
                    throw new Exception("Student Not Found.");
                }
                return student;
            }
        }


    }
}
