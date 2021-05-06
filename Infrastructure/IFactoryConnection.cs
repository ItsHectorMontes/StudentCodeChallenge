using System.Data;


namespace Infrastructure
{
    /// <summary>
    /// Interface to implement the connection.
    /// </summary>
    public interface IFactoryConnection
    {
        void CloseConnection();
        IDbConnection GetConnection();
    }
}
