using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Users

    {
        [BsonId]
        public string? Id { get; set; }

        [BsonElement("fName")]
        public string? FName { get; set; }

        [BsonElement("lName")]
        public string? LName { get; set; }

        [BsonElement("address")]
        public string? Address { get; set; } 

        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("mobile")]
        public string? Mobile { get; set; }
        [BsonElement("password")]
        public string? Password { get; set; }
        [BsonElement("nic")]
        public string? NIC { get; set; }
        [BsonElement("category")]
        public string? Category { get; set; }
    }
}
