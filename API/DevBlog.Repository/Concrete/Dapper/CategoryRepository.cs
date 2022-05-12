using Dapper;
using DevBlog.Entities.Concrete;
using DevBlog.Entities.Dtos.Category;
using DevBlog.Repository.Abstract;
using System.Data;

namespace DevBlog.Repository.Concrete.Dapper
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbConnection _connection;
        public CategoryRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<Category>> GetAll()
        {
            var query = "select * from categories";
            var response = await _connection.QueryAsync<Category>(query);
            return response.ToList();
        }

        public async Task<Category> GetById(int id)
        {
            var query = $"select * from categories where id={id}";
            var repsonse = await _connection.QuerySingleAsync<Category>(query);
            return repsonse;
        }

        public async Task<bool> Add(CategoryAddDto categoryAddDto)
        {
            var query = "insert into categories(title, createdDate) values(@title, @createddate)";
            var response = await _connection.ExecuteAsync(query, new { title = categoryAddDto.Title, createddate = DateTime.Now });
            return response == 1 ? true : false;
        }

        public async Task<bool> Update(int id, CategoryUpdateDto categoryUpdateDto)
        {
            var query = $"update categories set title=@title, updateddate=@updateddate where id={id}";
            var response = await _connection.ExecuteAsync(query, new { title = categoryUpdateDto.Title, updateddate = DateTime.Now });
            return response == 1 ? true : false;
        }

        public async Task<bool> Delete(int id)
        {
            var query = $"delete from categories where id={id}";
            var response = await _connection.ExecuteAsync(query);
            return response == 1 ? true : false;
        }
    }
}
