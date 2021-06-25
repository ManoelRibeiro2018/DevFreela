using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModel;
using DevFreela.Core.Entites;
using DevFreela.Insfrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    
        public List<UserViewModel> GetAll()
        {
            var user = _dbContext.Users.Select(u => new UserViewModel( u.FullName, u.Email)).ToList();
            return user;
        }

        public UserViewModel GetById(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            var userView = new UserViewModel(user.FullName, user.Email);
            return userView;
        }

     
    }
}
