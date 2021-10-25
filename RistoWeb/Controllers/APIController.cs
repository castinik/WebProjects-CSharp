using Microsoft.AspNetCore.Mvc;
using RistoWeb.Repository;
using System;

namespace RistoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private DBManagerRepo dbManager;
        public APIController(DBManagerRepo dbManager)
        {
            this.dbManager = dbManager;
        }
        [HttpGet("RemoveReservation")]
        public IActionResult RemoveReservation(Guid resId)
        {
            try
            {
                dbManager.CancelReservation(resId);
            }
            catch
            {

            }
            return Ok();
        }

        [HttpPost("try")]
        public IActionResult tryPost([FromBody] string stringa)
        {
            if (string.IsNullOrEmpty(stringa))
                return BadRequest("Stringa vuota");
            return Ok("Hai inviato: " + stringa);
        }
    }
}
