using Core_MVc_Api_MONGODB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_MVc_Api_MONGODB.Repository
{
    public interface IBlogRepository
    {
        Task<IEnumerable<Blog>> GetAllBlogs();
        Task<Blog> GetBlog(string id);
        Task AddBlog(Blog item);
        Task<bool> RemoveBlog(string id);
        Task UpdateBlog(string id, IEnumerable<KeyValuePair<string, string>> keyValues);
        Task<bool> PostComment(string id, BlogComment comment);
        Task RemoveAllBlogs();
    }
}
