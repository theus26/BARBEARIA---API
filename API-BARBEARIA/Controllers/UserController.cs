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

        [HttpPatch]
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


        [HttpPatch]
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

    }
}
