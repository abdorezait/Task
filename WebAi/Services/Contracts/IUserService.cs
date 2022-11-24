using System.Collections;
using System.Collections.Generic;
using WebAi.Entities;

namespace WebAi.Services.Contracts
{
    public interface IUserService
    {
        User Authenticate(string userName,string password);
        List<User> GetAll();

    }
}