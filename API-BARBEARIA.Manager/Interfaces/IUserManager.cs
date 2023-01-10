using API_BARBEARIA.DAL.Entities;
using API_BARBEARIA.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BARBEARIA.Manager.Interfaces
{
    public interface IUserManager
    {
        string RegisterUser(UserRegisterDTO userRegister);
    }
}
