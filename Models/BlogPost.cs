using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlogApi.Models
{
    public class BlogPost
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string _id { get; set; }

        public string Title { get; set; }
        public string Article { get; set; }
        public string CreationDate { get; set; }
        public string UpdateDate { get; set; }
        public string Author { get; set; }
    }
}
