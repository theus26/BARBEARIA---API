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
                    Error = "There was an error registering, please try again!"
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
                    Error = "Failed to schedule, please try again."
                });
            }

        }

        [HttpPatch]
        public IActionResult UpdateUser(UpdateUserDTO UserUpdate)
        {
            try
            {
                var Update = _userManager.UpdateUser(UserUpdate);
                return Ok(Update);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new RespostaErrorDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Failed to Update, please try again."
                });
            }
        }

        [HttpDelete ("{IdUser}")]
        public IActionResult DeleteUser (long Iduser)
        {
            var deleteUser = _userManager.DeleteUser(Iduser);
            return Ok(deleteUser);
        }

        
        
    }
}
