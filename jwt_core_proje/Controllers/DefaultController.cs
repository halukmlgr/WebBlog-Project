using jwt_core_proje.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jwt_core_proje.Controllers
{
   
    [Route("[controller]")]
    [ApiController]
    public class DefaultController : Controller
    {
        [HttpGet("[action]")]
        public IActionResult Login()//Token oluşturma kısmı 
        {
            return Created("",new BuildToken().CreateToken());
        }
        [Authorize]
        [HttpGet("[action]")]//Oluşturulan tokende girilen metni okuma kısmı
        public IActionResult Page1()
        {
            return Ok("Sayfa1 erişiminiz başarılı.");
        }
    }
}
