using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Doctor_Business_Logic;
using Model;
using Doctor;

namespace service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly ILogic _logic;
        public DoctorController(ILogic logic)
        {
            _logic = logic;
        }
        [HttpGet("getAll")]
        public ActionResult Get()
        {
            var Doct = _logic.GetAllDocts();
            if (Doct != null)
            {
                return Ok(Doct);
            }
            else
            {
                return BadRequest(Doct);
            }
        }
        [HttpGet("particular/{email}")]
        public ActionResult Getp([FromRoute] string email)
        {
            var users = _logic.GetDoct(email);
            if (users != null)
            {
                return Ok(users);
            }
            else
            {
                return BadRequest(users);
            }
        }
        [HttpPost("Add")]
        public ActionResult Post([FromBody] doctorr user)
        {
            var users = _logic.ADD(user);
            if (users != null)
            {
                return Ok(users);
            }
            else
            {
                return BadRequest(users);
            }
        }



    }
}
