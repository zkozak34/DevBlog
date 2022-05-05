using Dapper;
using DevBlog.Entities.Concrete;
using DevBlog.Entities.Dtos.Post;
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

        public async Task<Post> GetById(int id)
        {
            var query = $"select * from posts where id={id}";
            var response = await _connection.QuerySingleAsync<Post>(query);
            return response;
        }

        public async Task<bool> Add(PostAddDto postAddDto)
        {
            var query = "insert into posts(title,content,thumbnailimage,authorid,categoryid,createddate) values(@title,@content,@thumbnailimage,@authorid,@categoryid,@createddate)";
            var response = await _connection.ExecuteAsync(query, new
            {
                title = postAddDto.Title,
                content = postAddDto.Content,
                thumbnailimage = postAddDto.ThumbnailImage,
                authorid = postAddDto.AuthorId,
                categoryid = postAddDto.CategoryId,
                createddate = DateTime.Now
            });
            return response == 1 ? true : false;
        }

        public async Task<bool> Update(int id, PostUpdateDto postUpdateDto)
        {
            var query =
                $"update posts set title=@title, content=@content, thumbnailimage=@thumbnailimage, authorid=@authorid, categoryid=@categoryid, updateddate=@updateddate where id={id}";
            var response = await _connection.ExecuteAsync(query,
                new
                {
                    title = postUpdateDto.Title,
                    content = postUpdateDto.Content,
                    thumbnailimage = postUpdateDto.ThumbnailImage,
                    authorid = postUpdateDto.AuthorId,
                    categoryid = postUpdateDto.CategoryId,
                    updateddate = DateTime.Now
                });
            return response == 1 ? true : false;
        }

        public async Task<bool> Delete(int id)
        {
            var query = $"delete from posts where id={id}";
            var response = await _connection.ExecuteAsync(query);
            return response == 1 ? true : false;
        }
    }
}
