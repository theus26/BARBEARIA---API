using API_BARBEARIA.Attributes;
using API_BARBEARIA.DTO;
using API_BARBEARIA.Manager.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_BARBEARIA.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")] 
    public class UserController : Controller
    {
        private readonly IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
           

        }
       
        [HttpGet]
        public ActionResult HealthCheck()
        {
            return Ok("I'm alive and working");
        }

        [AuthAttributes]
        [HttpGet]
        public IActionResult ValidateSession()
        {
            return Ok("Sesison Valid");
        }

        [HttpGet]
        public IActionResult GetAllShavys()
        {
            try
            {
                var GetShavys = _userManager.GetAllShavy();
                return Ok(GetShavys);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new RespostaErrorDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "There was an error registering, please try again!",
                    Details = ex.Message
                });
            }

        }

        [HttpGet]
        public IActionResult GetAllServices()
        {
            try
            {
                var GetService = _userManager.GetAllService();
                return Ok(GetService);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new RespostaErrorDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "There was an error registering, please try again!",
                    Details = ex.Message
                });
            }
        }

        [HttpGet]
        public IActionResult GetAllHoraries()
        {
            try
            {
                var GetHoraries = _userManager.GetAllHoraries();
                return Ok(GetHoraries);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new RespostaErrorDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "There was an error registering, please try again!",
                    Details = ex.Message
                });
            }
        }

        [HttpPost]
        public IActionResult RegisterUser(UserRegisterDTO userRegister)
        {
            try
            {
                //Estou Recebendo os dados do Usuario e passando para o manager.
                var User = _userManager.RegisterUser(userRegister);
                return Ok(User);

            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new RespostaErrorDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "There was an error registering, please try again!",
                    Details = ex.Message
                });
            }
        }

        [AuthAttributes]
        [HttpGet("{IdUser}")]
        public IActionResult GetUserId(long IdUser)
        {
            try
            {
                var getUser = _userManager.GetUserId(IdUser);
                return Ok(getUser);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new RespostaErrorDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Incorrect email or password, please try again.",
                    Details = ex.Message
                });
            }


        }


        [HttpPost]
        public IActionResult Login(LoginDTO login)
        {
            try
            {
                //Estou recebendo os dados do user e será validado no manager
                var UserLogin = _userManager.Login(login);
                return Ok(UserLogin);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new RespostaErrorDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Incorrect email or password, please try again."
                });
            }
        }
        [AuthAttributes]
        [HttpPost]
        public IActionResult Scheduling(SchedulingDTO scheduling)
        {
            try
            {
                //Estou recebendo os dados do user e será validado no manager
                var Sendscheduling = _userManager.RegisterScheduling(scheduling);
                return Ok(Sendscheduling);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new RespostaErrorDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Failed to schedule, please try again.",
                    Details = ex.Message
                });
            }

        }
        [AuthAttributes]
        [HttpPut]
        public IActionResult UpdateUser(UpdateUserDTO UserUpdate)
        {
            try
            {
                //Recebe os dados e enviar ao manager para validar e editar usuario
                var Update = _userManager.UpdateUser(UserUpdate);
                return Ok(Update);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new RespostaErrorDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Failed to Update, please try again.",
                    Details  = ex.Message 
                });
            }
        }
        [AuthAttributes]
        [HttpDelete ("{IdUser}")]
        public IActionResult DeleteUser (long Iduser)
        {
            try
            {
                //Deletar usuario pelo seu Id
                var deleteUser = _userManager.DeleteUser(Iduser);
                return Ok(deleteUser);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new RespostaErrorDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Failed to Delete, please try again.",
                    Details = ex.Message
                });
            }

        }

        [AuthAttributes]
        [HttpPut]
        public IActionResult UpdateScheduling(UpdateSchedulingDTO updateScheduling)
        {
            try
            {
                //Recebe os dados e enviar ao manager para validar e editar agendamento
                var SchedulingUpdate = _userManager.UpdateScheduling(updateScheduling);
                return Ok(SchedulingUpdate);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new RespostaErrorDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Failed to Update, please try again",
                    Details = ex.Message
                });
            }
        }
        [AuthAttributes]
        [HttpDelete ("{IdScheduling}")]
        public IActionResult DeleteScheduling(long IdScheduling)
        {
            try
            {
                //Apaga agendamento pelo Id do agendamento
                var DeleteScheduling = _userManager.DeleteScheduling(IdScheduling);
                return Ok(DeleteScheduling);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new RespostaErrorDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Failed to Delete, please try again",
                    Details = ex.Message
                });
            }
        }
        [AuthAttributes]
        [HttpPost]
        public IActionResult SchedulingCompleted(SchedulingCompletedDTO schedulingCompleted)
        {
            try
            {
                //Estou recebendo os dados do user e será validado no manager
                var CompletedScheduling = _userManager.CompletedScheduling(schedulingCompleted);
                return Ok(CompletedScheduling);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new RespostaErrorDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Failed to Completed Scheduling, please try again",
                    Details = ex.Message
                });
            }
        }
        [AuthAttributes]
        [HttpGet]
        public IActionResult GetAllScheduling()
        {
            try
            {
                var getScheduling = _userManager.GetallScheduling();
                return Ok(getScheduling);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new RespostaErrorDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Failed to get all scheduling, please try again",
                    Details = ex.Message
                });
            }
        }
        [AuthAttributes]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var getUsers = _userManager.GetallUsers();
                return Ok(getUsers);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new RespostaErrorDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Failed to get all Users, please try again",
                    Details = ex.Message
                });
            }
        }
        [AuthAttributes]
        [HttpGet("{IdUser}")]
        public IActionResult GetSchedulingPerIdUser(long IdUser)
        {
            try
            {
                var getSchedulingPerUser = _userManager.GetScgedulingPerId(IdUser);
                return Ok(getSchedulingPerUser);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new RespostaErrorDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Failed to get Scheduling per Id, please try again",
                    Details = ex.Message
                });
            }

        }

        [HttpGet ("{NameBarber}")]
        public IActionResult GetBarberAppointment(string NameBarber)
        {
            try
            {
                var getAllBarber = _userManager.SchedulingsBarbers(NameBarber);
                return Ok(getAllBarber);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new RespostaErrorDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Failed to get Scheduling from the barber, please try again",
                    Details = ex.Message
                });
            }


        }

        
        [HttpGet]
        public IActionResult WarningRoutine()
        {
            try
            {
                var SendEmails = _userManager.WarningsRoutine();
                return Ok(SendEmails);

            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new RespostaErrorDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Failed to send notifications, please try again",
                    Details = ex.Message
                });
            }

        }

        [HttpPost]
        public IActionResult Logout(LogoutDTO logout)
        {
            try
            {
                var logof = _userManager.Logout(logout);
                return Ok(logof);

            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new RespostaErrorDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Failed to finalized session, please try again",
                    Details = ex.Message
                });
            }
        }
    }
    }

