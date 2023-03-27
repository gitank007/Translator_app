using System;
using hunderan_app.ApiModel;
using hunderan_app.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace hunderan_app.Controllers
{
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly DbComm _db;
                    
        public SearchController(ApiDbContext apiDbContext)
        {
            _db = new DbComm(apiDbContext);
        }

      [HttpGet]
        [DisableCors]
        [Route("engTraslation/{text}")]

        public ActionResult GetTranslationBytext(string text)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var data = _db.GetTraslatedtext();
                if (data == null)
                {
                    type = ResponseType.NotFound;

                }
                else
                {
                    var translatedtext = data.Where(t => t.SourceEng.Equals(text,StringComparison.OrdinalIgnoreCase));
                    if (translatedtext == null)
                    {
                        type = ResponseType.NoTranslationIsPresent;
                        
                    }
                    else
                    {
                        return Ok(translatedtext.FirstOrDefault().Targetlanguage);
                    }
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

