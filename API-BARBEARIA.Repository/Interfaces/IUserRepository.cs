using API_BARBEARIA.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BARBEARIA.Repository.Interfaces
{
    public interface IUserRepository
    {
        User RegisterUser(string Name, string Email, string CPF, string Password, string Phone, bool IsAdminBarber);
    }
}
