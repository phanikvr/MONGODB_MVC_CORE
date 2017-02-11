using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Core_MVc_Api_MONGODB.Core;
using Core_MVc_Api_MONGODB.Repository;
using Core_MVc_Api_MONGODB.Model;

namespace Core_MVc_Api_MONGODB.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IBlogRepository _repository;
        public ValuesController(IBlogRepository repository)
        {
            _repository = repository;
        }


        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Blog>> Get()
        {
            return await _repository.GetAllBlogs();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Blog> Get(string id)
        {
            return await _repository.GetBlog(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<string> Post([FromBody]Blog input)
        {
            await _repository.AddBlog(input);
            return input.Id;
        }

        // POST api/values
        [HttpPost]
        [Route("Comments/{id}")]
        public async Task<string> PostComment(string id, [FromBody]BlogComment input)
        {
            await _repository.PostComment(id, input);
            return input.DateCreated.ToString();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody]IEnumerable<KeyValuePair<string, string>> keyValues)
        {
           await _repository.UpdateBlog(id, keyValues);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _repository.RemoveBlog(id);
        }
    }
}
