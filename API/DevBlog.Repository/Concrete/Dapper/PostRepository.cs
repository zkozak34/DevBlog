using Dapper;
using DevBlog.Entities.Concrete;
using DevBlog.Repository.Abstract;
using System.Data;

namespace DevBlog.Repository.Concrete.Dapper
{
    public class PostRepository : IPostRepository
    {
        private readonly IDbConnection _connection;

        public PostRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<Post>> GetAll()
        {
            var query = "select * from posts order by id asc;";
            var response = await _connection.QueryAsync<Post>(query);
            return response.ToList();
        }
    }
}
