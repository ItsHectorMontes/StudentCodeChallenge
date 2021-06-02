using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SpStudent
{
    /// <summary>
    /// Student Interface
    /// </summary>
    public interface IStudent
    {
        Task<IEnumerable<StudentModel>> GetStudentsAsync();
        Task<IEnumerable<StudentModel>> GetStudentsAsyncByParameters(string parameters);
    }
}
