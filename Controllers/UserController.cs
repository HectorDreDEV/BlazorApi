using BlazorApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public static List<UserModel> Users = new List<UserModel>
        {
            new UserModel
            {
                Id = 1,
                FirstName = "one",
                LastName = "oneLast"
            },
            new UserModel
            {
                Id = 2,
                FirstName = "two",
                LastName = "twolast"
            },
            new UserModel
            {
                Id = 3,
                FirstName = "three",
                LastName = "threelast"
            },
        };

        [HttpGet]
        public List<UserModel> Get()
        {
            return Users;
        }

        [Route("{id}")]
        [HttpGet]
        public UserModel Get(int id)
        {
            return Users.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
       public int Create(UserModel model)
       {
            Users.Add(model);
            return model.Id;
       }

        [HttpPut]
        public int Update(UserModel model)
        {
            var user = Users.FirstOrDefault(x => x.Id == model.Id);
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            return model.Id;
        }

        [HttpDelete]
        public int Delete(int id)
        {
            var user = Users.FirstOrDefault(x => x.Id == id);
            Users.Remove(user);
            return user.Id;
        }
    }
}
