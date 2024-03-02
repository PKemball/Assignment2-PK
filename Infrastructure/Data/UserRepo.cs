using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UserRepo : IRepo<User>
    {
        private DbContext context;

        public UserRepo(DbContext context)
        {
            this.context = context;
        }
        public void CommitChanges()
        {
            context.SaveChanges();
        }

        public User CreateEntity(User entity)
        {
            var dbSet = context.Set<User>();
            dbSet.Add(entity);
            return entity;
        }

        public void DeleteById(int id)
        {
            var dbSet = context.Set<User>();
            var foundEntity = dbSet.Where(entity => entity.Id == id).First();
            if (foundEntity != null)
            {
                dbSet.Remove(foundEntity);
            }
        }

        public User FindById(int id)
        {
            var dbSet = context.Set<User>();
            var foundEntity = dbSet.Where(entity => entity.Id == id).First();
            return foundEntity;
        }

        public List<User> GetAll()
        {
            var dbSet = context.Set<User>();
            return dbSet.ToList();
        }
        public void ListAllToConsole()
        {
            var users = GetAll();
            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id}");
                Console.WriteLine($"Name: {user.Name}");
                Console.WriteLine($"Email: {user.EmailAddress}");
                Console.WriteLine($"Phone: {user.PhoneNumber}");
            }
        }

        public void Update(User entity)
        {
            var dbSet = context.Set<User>();
            var foundEntity = dbSet.Where(e => e.Id == entity.Id).First();
            if (foundEntity == null)
            {
                CreateEntity(entity);
                return;
            }

            var userType = typeof(User);
            var properties = userType.GetProperties();
            foreach (var property in properties)
            {
                var value = property.GetValue(entity);
                property.SetValue(foundEntity, value);
            }

            entity.LastUpdatedDateTime = DateTime.Now;
        }
    }
}
