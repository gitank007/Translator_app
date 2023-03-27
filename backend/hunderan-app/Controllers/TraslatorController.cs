using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hunderan_app.ApiModel;
using hunderan_app.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hunderan_app.Controllers
{

    [ApiController]
    public class TraslatorController : ControllerBase
    {
        private readonly DbComm _db;

        public TraslatorController(ApiDbContext apiDbContext)
        {
            _db = new DbComm(apiDbContext);
        }



        // GET: api/Traslator
        [HttpGet]
        [EnableCors]
        [Route("AllData")]

        public IActionResult GetTranslation()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var data = _db.GetTraslatedtext();

                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(Responsehandler.GetAppResponse(type, data));

            }

            catch (Exception ex)
            {
                type = ResponseType.Failure;
                return BadRequest(Responsehandler.GetExceptionResponse(ex));
            }

        }
    }

}

