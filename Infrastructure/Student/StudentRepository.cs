using Dapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SpStudent
{
    /// <summary>
    /// This class consume all data from Store Procedure,
    /// i've used 2 store procedure
    /// 1.- get all students.
    /// 2.- get students by name or surname or school.
    /// </summary>
    public class StudentRepository : IStudent
    {
        private readonly IFactoryConnection _factoryConnection;
        public StudentRepository(IFactoryConnection factoryConnection)
        {
            _factoryConnection = factoryConnection;
        }
        /// <summary>
        /// Get all students.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<StudentModel>> GetStudentsAsync()
        {
            IEnumerable<StudentModel> studentList = null;            
            var storeProcedure = "SP_Get_Students";
            try
            {
                var connection = _factoryConnection.GetConnection();
                studentList = await connection.QueryAsync<StudentModel>(storeProcedure, null, commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                throw new Exception("Error consulting database.", e);
            }
            finally
            {
                _factoryConnection.CloseConnection();
            }
            return studentList;
        }
        /// <summary>
        /// Get students using parameters.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<StudentModel> GetStudentsAsyncByParameters(string name)
        {
            var storeProcedure = "SP_Get_Students_By_Parameters";
            StudentModel student = null;
            try
            {
                var connection = _factoryConnection.GetConnection();
                student = await connection.QueryFirstAsync<StudentModel>(storeProcedure, new
                {
                    parameter = name
                },
                commandType: CommandType.StoredProcedure
                );
                _factoryConnection.CloseConnection();
                return student;
            }
            catch (Exception e)
            {
                throw new Exception("Student Not Found.", e);
            }
        }
    }
}
