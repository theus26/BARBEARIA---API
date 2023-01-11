using API_BARBEARIA.Commons.Services;
using API_BARBEARIA.Commons.Util;
using API_BARBEARIA.DAL.Entities;
using API_BARBEARIA.DTO;
using API_BARBEARIA.Manager.Interfaces;
using API_BARBEARIA.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace API_BARBEARIA.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public SucessLoginDTO Login(LoginDTO login)
        {
            try
            {
                //Validação para ver se os campos são nulos ou vazios.
                if (string.IsNullOrEmpty(login.Email)) throw new ArgumentException("Email can't be empty or null");
                if (string.IsNullOrEmpty(login.Password)) throw new ArgumentException("Password can´t be empty or null");

                // Validação do tamanho da string
                if (login.Email.Length <= 3) throw new ArgumentException("Email Inválid");
                if (login.Password.Length <= 7) throw new ArgumentException("Password be more than characters");

                //Validação com Regex
                //Email
                var EmailParser = new Regex(@"^([\w\.\-\+\d]+)@([\w\-]+)((\.(\w){2,3})+)$");
                var EmailMatches = EmailParser.Matches(login.Email);
                if (EmailMatches.Count == 0) throw new ArgumentException("Please enter a Email Valid");

                //Password
                var PasswordParser = new Regex(@"[a-zA-Z0-9]+");
                var PasswordMatches = PasswordParser.Matches(login.Password);
                if (PasswordMatches.Count == 0) throw new ArgumentException("Please password must contain letters and numbers");

                // Criar hash da senha 
                var password = MD5Helper.CreateHashMd5(login.Password);

                //Verifica se a algum usuario
                var userValid = _userRepository.UserIsValid(login.Email, password);

                //pegar os dados para gerar o Token
                var userToken = new User()
                {
                    IdUser = userValid.IdUser,
                    Email = userValid.Email

                };
                //Gerãção do Token
                var token = TokenService.criarToken(userToken);

                //Mensagem de sucesso
                var MessageSucess = new SucessLoginDTO()
                {
                    Message = "Successful login",
                    IdUser = userValid.IdUser,
                    Token = token,
                    IsBarber = userValid.BarberAdmin

                };



                return MessageSucess;

            }
            catch
            {
                throw;
            }
        }

        public string RegisterUser(UserRegisterDTO userRegister)
        {
            try
            {
                //Validação para ver se os campos são nulos ou vazios.
                if(string.IsNullOrEmpty(userRegister.Email))  throw new ArgumentException("Email can't be empty or null");
                if (string.IsNullOrEmpty(userRegister.Name)) throw new ArgumentException("Name can´t be empty or null ");
                if (string.IsNullOrEmpty(userRegister.Phone)) throw new ArgumentException("Phone can´t be empty or null");
                if (string.IsNullOrEmpty(userRegister.CPF)) throw new ArgumentException("CPF can´t be empty or null");
                if (string.IsNullOrEmpty(userRegister.Password)) throw new ArgumentException("Password can´t be empty or null");

                //Validação para o tamanho de cada campo
                if (userRegister.Email.Length < 3) throw new ArgumentException("Email must be more than 3 characters");
                if (userRegister.Name.Length < 3) throw new ArgumentException("Name must be more than 3 characters");
                if (userRegister.Phone.Length < 3) throw new ArgumentException("Phone must be more than 3 characters");
                if (userRegister.Phone.Length >= 14) throw new ArgumentException("Phone must have less than 12 characters");
                if (userRegister.CPF.Length >= 15) throw new ArgumentException("CPF must have less than 11 characters");
                if (userRegister.CPF.Length < 11) throw new ArgumentException("CPF must be more than 3 characters");
                if (userRegister.Password.Length < 3) throw new ArgumentException("Password be more than 3 characters");

                //Validação com o uso do Regex

                //Email
                var EmailParser = new Regex(@"^([\w\.\-\+\d]+)@([\w\-]+)((\.(\w){2,3})+)$");
                var EmailMatches = EmailParser.Matches(userRegister.Email);
                if (EmailMatches.Count == 0) throw new ArgumentException("Please enter a Email Valid");

                //Name
                var NameParser = new Regex(@"^[a-zA-Z]+");
                var NameMatches = NameParser.Matches(userRegister.Name);
                if (NameMatches.Count == 0) throw new ArgumentException("Please enter a Name valid");

                //Phone
                var PhoneParser = new Regex(@"([1-9]{2})? ?(?:[2-8]|9[1-9])[0-9]{3}-?[0-9]{4}$");
                var PhoneMatches = PhoneParser.Matches(userRegister.Phone);
                if (PhoneMatches.Count == 0) throw new ArgumentException("Please enter a Phone Valid");

                //CPF
                var CPFParser = new Regex(@"([0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2})+$");
                var CPFMatches = CPFParser.Matches(userRegister.CPF);
                if (CPFMatches.Count == 0) throw new ArgumentException("Please enter a CPF valid");

                //Password
                var PasswordParser = new Regex(@"[a-zA-Z0-9]+");
                var PasswordMatches = PasswordParser.Matches(userRegister.Password);
                if (PasswordMatches.Count == 0) throw new ArgumentException("Please password must contain letters and numbers");

                var password = MD5Helper.CreateHashMd5(userRegister.Password);

                //Implementação com o Repository
                _userRepository.RegisterUser(userRegister.Name, userRegister.Email, userRegister.CPF, password, userRegister.Phone, userRegister.IsBarberAdmin);

                return "New User Created";


            }

            catch(Exception ex)
            {
                throw new OperationCanceledException("Could not register a User! " + ex.Message);
            }
        }
    }
}
