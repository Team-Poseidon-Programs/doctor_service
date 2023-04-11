using Doctor_Business_Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAvailblityController : ControllerBase
    {
        private readonly ILogic _logic;
        public DoctorAvailblityController(ILogic logic)
        {
            _logic = logic;
        }

        [HttpGet("particular/{email}")]
        public ActionResult GetAva([FromRoute] string email)
        {
            var users = _logic.GetDoctrAv(email);
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
        public ActionResult Post([FromBody] doctor_availability user)
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

        [HttpPut("Update/{email}")]
        public ActionResult Put([FromRoute] string email, [FromBody] doctor_availability u)
        {
            var users = _logic.UpdateDoctorAv(u, email);
            if (users != null)
            {
                return Ok(users);
            }
            else
            {
                return BadRequest(users);
            }
        }

        [HttpGet("getdocbyStatus/{status}")]
        public ActionResult getdocbystat([FromRoute] bool status)
        {
            var users = _logic.getDocByStatus(status);
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
