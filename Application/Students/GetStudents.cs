using Domain.Models;
using Infrastructure.SpStudent;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Students
{
    /// <summary>    
    /// This class get all data of students, it have sent from insfractructure,
    /// then this class send it to controller.
    /// </summary>
    public class GetStudents
    {
        public class ListStudents : IRequest<List<StudentModel>>
        {

        }
        public class Handler : IRequestHandler<ListStudents, List<StudentModel>>
        {
            private readonly IStudent _studentRepository;
            public Handler(IStudent studentRepository)
            {
                _studentRepository = studentRepository;
            }        

            public async Task<List<StudentModel>> Handle(ListStudents request, CancellationToken cancellationToken)
            {
                var resultado = await _studentRepository.GetStudentsAsync();
                return resultado.ToList();
            }
        }
    }
}
