using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Core_MVc_Api_MONGODB.Model
{
    //[BsonIgnoreExtraElements] // use this annotation while reading data to ignore any serialization erros and gets u some data
    public class Blog
    {
        /// <summary>
        /// mongo Id is mapped to the id
        /// //[BsonId] 
        /// public ObjectId Id { get; set; } // if u want an object instead of string id,u need to use this to get metadata of the document, like create date etc
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]        
        public string Id { get; set; }
        [BsonElement("BlogUser")]
        public BlogUser User { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string By { get; set; }
        public string Url { get; set; }
        public int Likes { get; set; }
        public IEnumerable<BlogComment> Comments { get; set; }
        [BsonIgnoreIfNull]
        public IEnumerable<string> Tags { get; set; }
    }

    public class BlogComment
    {
        [BsonElement("User")] // changing the name of the element
        public string PostedBy { get; set; }
        public string Message { get; set; }
        [BsonElement("DateCreated")] // changing the name of the element
        public DateTime DateCreated { get; set; }
        [BsonRepresentation(BsonType.Boolean, AllowOverflow = true)] // converting int to boolean
        public bool Like { get; set; }
        
    }
    public class BlogUser
    {
        public string UserId { get; set; }
        public string DisplayName { get; set; }
        public int Age { get; set; }
    }
}
