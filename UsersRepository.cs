﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TestEntityFramework.Models;

namespace TestEntityFramework
{
    public class UsersRepository
    {
        private TestDbContext dbContext;

        public UsersRepository(TestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<UserView> GetUsers()
        {
            return dbContext.Users.
                Select(user => new UserView
                {
                    Id = user.Id,
                    Login = user.Login,
                    PersonName = user.Person.FirstName + " " + user.Person.LastName + " " + user.Person.MiddleName,
                    role = user.Role.Name
                }).ToList();
        }

        public List<UserView> GetUsers(Person person)
        {
            return dbContext.Users.Where(user => user.Person.Id == person.Id).
                Select(user => new UserView
                {
                    Id = user.Id,
                    Login = user.Login,
                    PersonName = user.Person.FirstName + " " + user.Person.LastName + " " + user.Person.MiddleName,
                    role = user.Role.Name
                }).ToList();
        }

        public List<UserView> GetUsers(Role role)
        {
            return dbContext.Users.Where(user => user.Role.Id == role.Id).
            Select(user => new UserView
            {
                Id = user.Id,
                Login = user.Login,
                PersonName = user.Person.FirstName + " " + user.Person.LastName + " " + user.Person.MiddleName,
                role = user.Role.Name
            }).ToList();
        }
       

        public User GetUser(long userId)
        {
            return dbContext.Users.FirstOrDefault(u => u.Id == userId);
        }

        public User GetUser(string login)
        {
            return dbContext.Users.FirstOrDefault(user => user.Login == login);
        }

        public User AddUser(User user)
        {
            User newUser = dbContext.Users.Add(user);
            dbContext.SaveChanges();

            return newUser;
        }

        public User UpdateUser(User user)
        {
            dbContext.Users.Attach(user);
            dbContext.Entry(user).State = EntityState.Modified;
            dbContext.SaveChanges();

            return user;
        }

        

        
    }
}