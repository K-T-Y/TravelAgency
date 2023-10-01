using Application.IServices;
using Domain.IRepos;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services 
{
    public class UserService:IUserService
    {
        private readonly IMongoCollection<Users> _students;

        public UserService(ITravelAgencyDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("travelDB");
            _students = database.GetCollection<Users>("users");
        }

        public Users Create(Users student)
        {
            _students.InsertOne(student);
            return student;
        }

        public List<Users> Get()
        {
            return _students.Find(student => true).ToList();
        }

        public Users Get(string id)
        {
            return _students.Find(student => student.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _students.DeleteOne(student => student.Id == id);
        }

        public void Update(string id, Users student)
        {
            _students.ReplaceOne(student => student.Id == id, student);
        }

    }
}
