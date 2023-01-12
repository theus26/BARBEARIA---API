using API_BARBEARIA.DAL.DAO;
using API_BARBEARIA.DAL.Entities;
using API_BARBEARIA.DAL.Enums;
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

        public User GetEmail(long IdUser)
        {
           var getuser = _userDAO.GetAll().FirstOrDefault(x=> x.IdUser == IdUser);
           return getuser;
        }

        public Scheduling GetScheduling(long IdUser)
        {
            var getscheduling = _schedulingDAO.GetAll().FirstOrDefault(x => x.IdUser == IdUser);
            return getscheduling;
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

        public Scheduling scheduling(long IdUser, DateTime HairCurtDate, string DesiredService, string Time, BarberEnum barberEnum)
        {
            if (DesiredService.Count() < 2 || Time.Count() < 2)
            {
                throw new OperationCanceledException("Could not create a new user, some fields may be invalid");
            }

            var UserId = _userDAO.GetAll().Where(x => x.IdUser == IdUser);
            if (!UserId.Any())
            {
                throw new OperationCanceledException("User Don´t exist");
            }

            var ThereIstime = _schedulingDAO.GetAll().Where(x => x.Time == Time && x.HairCurtDate == HairCurtDate);
            
            if (ThereIstime.Any())
            {
                throw new OperationCanceledException("time already scheduled, please choose another time");
            }

           

            var Salved = new Scheduling()
            {
                IdUser = IdUser,
                Time = Time,
                DesiredService = DesiredService,
                HairCurtDate = HairCurtDate,
                Barber = barberEnum

            };
            _schedulingDAO.Create(Salved);

            var newSalved = new Barber()
            {
                IdSchedulling = Salved.IdSchedulling,
                Name = Salved.Barber.ToString()
            };
            _barberDAO.Create(newSalved);

            return Salved;
        }

        public User UserIsValid(string Email, string Password)
        {
            var User = _userDAO.GetAll().FirstOrDefault(x => x.Email == Email && x.Password == Password);
            if (User == null)
            {
                throw new OperationCanceledException("Usuário e/ou Senha incorretos. Tente novamente.");
            }
            return User;

        }
    }
}
