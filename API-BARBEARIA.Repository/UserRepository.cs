using API_BARBEARIA.DAL.DAO;
using API_BARBEARIA.DAL.Entities;
using API_BARBEARIA.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BARBEARIA.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDAO<User> _userDAO;
        private readonly IDAO<Scheduling> _schedulingDAO;
        private readonly IDAO<Barber> _barberDAO;

        public UserRepository(IDAO<User> userDAO, IDAO<Scheduling> schedulingDAO, IDAO<Barber> barberDAO)
        {
            _userDAO = userDAO;
            _schedulingDAO = schedulingDAO;
            _barberDAO = barberDAO;
        }

        public User RegisterUser(string Name, string Email, string CPF, string Password, string Phone, bool IsAdminBarber)
        {
            try
            {
                if (Email.Count() < 2 || CPF.Count() < 3 || Name.Count() < 3 || Phone.Count() < 3 || Password.Count() < 3)
                {
                    throw new OperationCanceledException("Could not create a new user, some fields may be invalid");
                }

                var ThereiIsCPF = _userDAO.GetAll().Where(x => x.CPF == CPF);
                if (ThereiIsCPF.Any())
                {
                    throw new OperationCanceledException("User already existis with CPF");
                }
                var ThereIsEmail = _userDAO.GetAll().Where(x => x.Email == Email);
                if (ThereIsEmail.Any())
                {
                    throw new OperationCanceledException("User already existis with Email");
                }
                var ThereIsPhone = _userDAO.GetAll().Where(x => x.Phone == Phone);
                if (ThereIsPhone.Any())
                {
                    throw new OperationCanceledException("User already existis with Phone");
                }

                var newUser = new User()
                {
                    Email = Email,
                    CPF = CPF,
                    UserName = Name,
                    BarberAdmin = IsAdminBarber,
                    Password = Password,
                    Phone = Phone,
                };
                _userDAO.Create(newUser);
                return newUser;
            }
            
            catch (Exception)
            {
                throw;
            }
        }
    }
}
