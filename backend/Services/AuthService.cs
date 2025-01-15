using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Helpers;
using backend.Models;
using backend.Services;
using MongoDB.Driver;

namespace backend.Controllers
{
    public class AuthService
    {
        private readonly IMongoCollection<User> _users;
        public AuthService(MongoDbService mongoDbService)
        {
            _users = mongoDbService.Users;
        }

        public async Task<bool> RegisterUserAsync(User user){
            var existingUser = await _users.Find(u => u.Email == user.Email).FirstOrDefaultAsync();
            if(existingUser != null) return false;

            var newUser = new User 
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = PasswordHasher.HashPassword(user.Password),
                MobileNo = user.MobileNo
            };

            await _users.InsertOneAsync(user);
            return true;
        }

        public async Task<User?> AuthenticateUserAsync(string email, string password ){
            var user = await _users.Find(u=> u.Email == email).FirstOrDefaultAsync();
            if(user == null || !PasswordHasher.VerifyPassword(password, user.Password))
                return null;
            return user;
        }
    }
}