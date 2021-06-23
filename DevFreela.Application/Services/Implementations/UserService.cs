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
        public int Create(UserInputModel inputModel)
        {
            var user = new User(inputModel.FullName,inputModel.Email, inputModel.BirthDate);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user.Id;
        }
        public void Update(int id, UserUpdateModel updateModel)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user != null)
            {
                user.Update(updateModel.FullName, updateModel.BirthDate);
                _dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user != null)
            {
                user.Deactivate();
                _dbContext.SaveChanges();
            }
        }

        public List<UserViewModel> GetAll()
        {
            var user = _dbContext.Users.Select(u => new UserViewModel(u.Id, u.FullName, u.Email, u.BirthDate)).ToList();
            return user;
        }

        public UserViewModel GetById(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            var userView = new UserViewModel(user.Id,user.FullName, user.Email, user.BirthDate);
            return userView;
        }

     
    }
}
