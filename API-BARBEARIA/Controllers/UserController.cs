using API_BARBEARIA.DTO;
using API_BARBEARIA.Manager.Interfaces;
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
                    Error = "Ocorreu erro ao se Registrar, Tente Novamente!"
                });
            }
        }
        
    }
}
