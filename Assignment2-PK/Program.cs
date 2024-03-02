// See https://aka.ms/new-console-template for more information

using Domain.Entities;
using Infrastructure.Data;
using System.Reflection.Metadata;

var dbContext = new DataContext();

var userRepo = new UserRepo(dbContext);

void TestDatabase(UserRepo repo)
{
    var newUser = new User()
    {
        Name = "Philip Kemball",
        EmailAddress = "kemballp@mymacewan.ca",
        PhoneNumber = "1234567890",
    };
    repo.CreateEntity(newUser);
    userRepo.CommitChanges();
    Console.WriteLine("Created user Philip Kemball:");
    userRepo.ListAllToConsole();

    var foundUserId = userRepo.GetAll().Select(x => x.Id).FirstOrDefault();
    var foundUser = userRepo.FindById(foundUserId);
    foundUser.Name = "Updated Philip Kemball";
    foundUser.EmailAddress = "Updated Email";
    foundUser.PhoneNumber = "999-999-9999";
    userRepo.Update(foundUser);
    userRepo.CommitChanges();
    Console.WriteLine("Updated user Updated Philip Kemball:");
    userRepo.ListAllToConsole();
    userRepo.DeleteById(foundUserId);
    userRepo.CommitChanges();
    Console.WriteLine("Deleted user Updated Philip Kemball:");
    userRepo.ListAllToConsole();
}

TestDatabase(userRepo);








