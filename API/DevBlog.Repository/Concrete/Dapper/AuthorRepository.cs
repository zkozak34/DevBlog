using Dapper;
using DevBlog.Entities.Dtos.Author;
using DevBlog.Repository.Abstract;
using System.Data;

namespace DevBlog.Repository.Concrete.Dapper
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IDbConnection _connection;

        public AuthorRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<AuthorDto>> GetAll()
        {
            var query = "select * from authors";
            var response = await _connection.QueryAsync<AuthorDto>(query);
            return response.ToList();
        }

        public async Task<AuthorDto> GetById(int id)
        {
            var query = $"select * from authors where id={id}";
            var response = await _connection.QuerySingleAsync<AuthorDto>(query);
            return response;
        }

        public async Task<bool> Add(AuthorAddDto authorAddDto)
        {
            var query =
                "insert into authors(fullname,email,password,profileimage,overview,createddate) values(@fullname,@email,@password,@profileimage,@overview,@createddate)";
            var response = await _connection.ExecuteAsync(query, new
            {
                fullname = authorAddDto.FullName,
                email = authorAddDto.Email,
                password = authorAddDto.Password,
                profileimage = authorAddDto.ProfileImage,
                overview = authorAddDto.Overview,
                createddate = DateTime.Now
            });
            return response == 1 ? true : false;
        }

        public async Task<bool> Update(int id, AuthorUpdateDto authorUpdateDto)
        {
            var query =
                $"update authors set fullname=@fullname, email=@email, profileimage=@profileimage, overview=@overview, updateddate=@updateddate where id={id}";
            var response = await _connection.ExecuteAsync(query, new
            {
                fullname = authorUpdateDto.FullName,
                email = authorUpdateDto.Email,
                profileimage = authorUpdateDto.ProfileImage,
                overview = authorUpdateDto.Overview,
                updateddate = DateTime.Now,
            });
            return response == 1 ? true : false;
        }

        public async Task<bool> Delete(int id)
        {
            var query = $"delete from authors where id={id}";
            var response = await _connection.ExecuteAsync(query);
            return response == 1 ? true : false;
        }

        public async Task<AuthorDto> Login(string email, string password)
        {
            var query = "select * from authors where email=@email and password=@password";
            var response = await _connection.QuerySingleAsync<AuthorDto>(query, new { email, password });
            return response;
        }
    }
}
