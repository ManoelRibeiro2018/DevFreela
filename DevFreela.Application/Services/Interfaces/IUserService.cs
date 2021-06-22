using DevFreela.Application.InputModel;
using DevFreela.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUserService
    {
        int Create(UserInputModel inputModel);
        void Update(int id, UserUpdateModel updateModel);
        void Delete(int id);
       List<UserViewModel> GetAll();
        UserViewModel GetById(int id);

    }
}
