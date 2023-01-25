using API_BARBEARIA.Commons.Services;
using API_BARBEARIA.Commons.Util;
using API_BARBEARIA.DAL.Entities;
using API_BARBEARIA.DTO;
using API_BARBEARIA.Manager.Interfaces;
using API_BARBEARIA.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

            catch
            {
                throw;
            }
        }

        public string RegisterScheduling(SchedulingDTO scheduling)
        {
            try
            {
                //Validação para ver se os campos são nulos ou vazios.
                if (string.IsNullOrEmpty(scheduling.DesiredService)) throw new ArgumentException("Desired Service can´t be empty or null");
                if (string.IsNullOrEmpty(scheduling.Time)) throw new ArgumentException("Time can´t be empty or null");
                if (scheduling.HairCurtDate.ToString() == "01/01/1900") throw new ArgumentException("Hair curte date can´t be empty or null");

                //validação de tamanho da string
                if (scheduling.DesiredService.Length <= 5) throw new ArgumentException("Desired Service must be more than 5 characters");
                if (scheduling.Time.Length < 3) throw new ArgumentException("Time must be more 3 Characters");
                if (scheduling.HairCurtDate.ToString().Length < 3) throw new ArgumentException("Hair curt date must be more 3 characters");
                if (scheduling.IdUser <= 0) throw new ArgumentException("There is no User with Iduser 0");
                if ( scheduling.HairCurtDate <= DateTime.Now) throw new ArgumentException("Date Invalid");

               

                //Envia dados para o repository
                var Sendscheduling = _userRepository.scheduling(scheduling.IdUser, scheduling.HairCurtDate, scheduling.DesiredService, scheduling.Time, scheduling.barberEnum);

                var GetUser = _userRepository.GetEmail(scheduling.IdUser);
       

                MailMessage mailMessage = new MailMessage("barbeariadesign170@gmail.com", GetUser.Email);

                mailMessage.Subject = $"Agendamento realizado!";
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = $"<h1> Olá, {GetUser.UserName}!  </h1> <br> <p> Vinhemos confirmar que,  seu agendamento foi realizado com sucesso,  para o dia, <b> {scheduling.HairCurtDate.Date}</b> as <b> {scheduling.Time}</b> horas, para realizar o serviço desejado: <b>{scheduling.DesiredService}</b> </p> <br> <hr> <br> Te Aguardamos ansiosamente.  ";
                mailMessage.SubjectEncoding = Encoding.GetEncoding("UTF-8");
                mailMessage.BodyEncoding = Encoding.GetEncoding("UTF-8");

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("barbeariadesign170@gmail.com", "psliiytyvwsrrcqb");

                smtpClient.EnableSsl = true;

                smtpClient.Send(mailMessage);




                return "appointment successfully made";

            }
            catch
            {
                throw;
            }
            

        }

        public UpdateUserDTO UpdateUser(UpdateUserDTO user)
        {
            try
            {
                //Validação para ver se os campos são nulos ou vazios.
                if (string.IsNullOrEmpty(user.Email)) throw new ArgumentException("Email can't be empty or null");
                if (string.IsNullOrEmpty(user.Name)) throw new ArgumentException("Name can´t be empty or null ");
                if (string.IsNullOrEmpty(user.Phone)) throw new ArgumentException("Phone can´t be empty or null");
                if (string.IsNullOrEmpty(user.CPF)) throw new ArgumentException("CPF can´t be empty or null");
                if (string.IsNullOrEmpty(user.Password)) throw new ArgumentException("Password can´t be empty or null");

                //Validação para o tamanho de cada campo
                if (user.Email.Length < 3) throw new ArgumentException("Email must be more than 3 characters");
                if (user.Name.Length < 3) throw new ArgumentException("Name must be more than 3 characters");
                if (user.Phone.Length < 3) throw new ArgumentException("Phone must be more than 3 characters");
                if (user.Phone.Length >= 14) throw new ArgumentException("Phone must have less than 12 characters");
                if (user.CPF.Length >= 15) throw new ArgumentException("CPF must have less than 11 characters");
                if (user.CPF.Length < 11) throw new ArgumentException("CPF must be more than 3 characters");
                if (user.Password.Length < 3) throw new ArgumentException("Password be more than 3 characters");

                //Validação com o uso do Regex

                //Email
                var EmailParser = new Regex(@"^([\w\.\-\+\d]+)@([\w\-]+)((\.(\w){2,3})+)$");
                var EmailMatches = EmailParser.Matches(user.Email);
                if (EmailMatches.Count == 0) throw new ArgumentException("Please enter a Email Valid");

                //Name
                var NameParser = new Regex(@"^[a-zA-Z]+");
                var NameMatches = NameParser.Matches(user.Name);
                if (NameMatches.Count == 0) throw new ArgumentException("Please enter a Name valid");

                //Phone
                var PhoneParser = new Regex(@"([1-9]{2})? ?(?:[2-8]|9[1-9])[0-9]{3}-?[0-9]{4}$");
                var PhoneMatches = PhoneParser.Matches(user.Phone);
                if (PhoneMatches.Count == 0) throw new ArgumentException("Please enter a Phone Valid");

                //CPF
                var CPFParser = new Regex(@"([0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2})+$");
                var CPFMatches = CPFParser.Matches(user.CPF);
                if (CPFMatches.Count == 0) throw new ArgumentException("Please enter a CPF valid");

                //Password
                var PasswordParser = new Regex(@"[a-zA-Z0-9]+");
                var PasswordMatches = PasswordParser.Matches(user.Password);
                if (PasswordMatches.Count == 0) throw new ArgumentException("Please password must contain letters and numbers");

                var password = MD5Helper.CreateHashMd5(user.Password);

                var EditUser = _userRepository.UpdateUser(user.IdUser, user.Name, user.Email, user.CPF, password, user.Phone, user.IsBarberAdmin);

                return user;
            }

            catch
            {
                throw;
            }
            
        }

        public string DeleteUser(long IdUser)
        {
            if (IdUser <= 0 )
            {
                throw new ArgumentException("Invalid UserID");
            }

            var delete = _userRepository.DeleteUser(IdUser);
            return $"IdUser:{IdUser} was Deleted";
        }

        public UpdateSchedulingDTO UpdateScheduling(UpdateSchedulingDTO scheduling)
        {
            try
            {
                //Validação para ver se os campos são nulos ou vazios.
                if (string.IsNullOrEmpty(scheduling.DesiredService)) throw new ArgumentException("Desired Service can´t be empty or null");
                if (string.IsNullOrEmpty(scheduling.Time)) throw new ArgumentException("Time can´t be empty or null");
                if (scheduling.HairCurtDate.ToString() == "01/01/1900") throw new ArgumentException("Hair curte date can´t be empty or null");

                //validação de tamanho da string
                if (scheduling.DesiredService.Length <= 5) throw new ArgumentException("Desired Service must be more than 5 characters");
                if (scheduling.Time.Length < 3) throw new ArgumentException("Time must be more 3 Characters");
                if (scheduling.HairCurtDate.ToString().Length < 3) throw new ArgumentException("Hair curt date must be more 3 characters");
                if (scheduling.IdScheduling <= 0) throw new ArgumentException("There is no User with Iduser 0");
                if (scheduling.HairCurtDate <= DateTime.Now) throw new ArgumentException("Date Invalid");

                //Envia dados para o repository
                var updateScheduling = _userRepository.UpdateScheduling(scheduling.IdScheduling, scheduling.IdUser, scheduling.HairCurtDate, scheduling.DesiredService, scheduling.Time, scheduling.barberEnum);


                var GetUser = _userRepository.GetEmail(scheduling.IdUser);


                MailMessage mailMessage = new MailMessage("barbeariadesign170@gmail.com", GetUser.Email);

                mailMessage.Subject = $"Agendamento Alterado com sucesso!";
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = $"<h1> Olá, {GetUser.UserName}!  </h1> <br> <p> Vinhemos confirmar que,  seu agendamento foi alterado para o dia, <b> {scheduling.HairCurtDate.Date}</b> as <b> {scheduling.Time}</b> horas, para realizar o serviço desejado: <b>{scheduling.DesiredService}</b> </p> <br> <hr> <br> Te Aguardamos ansiosamente.  ";
                mailMessage.SubjectEncoding = Encoding.GetEncoding("UTF-8");
                mailMessage.BodyEncoding = Encoding.GetEncoding("UTF-8");

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("barbeariadesign170@gmail.com", "psliiytyvwsrrcqb");

                smtpClient.EnableSsl = true;

                smtpClient.Send(mailMessage);




                return scheduling;
            }

            catch
            {
                throw;
            }


        }
    }
}
