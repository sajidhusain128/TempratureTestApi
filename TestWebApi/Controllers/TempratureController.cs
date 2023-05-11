using BAL.Service;
using Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace TestWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TempratureController : ControllerBase
    {
        private readonly IUnitConverstionService _unitConverstionService;

        public TempratureController(IUnitConverstionService unitConverstionService)
        {
            _unitConverstionService = unitConverstionService;
        }

        /// <summary>
        /// Get Temprature Converstion with from and to unit type with value
        /// </summary>
        /// <param name="FromUnit"></param>
        /// <param name="ToUnit"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        [HttpGet("GetConverstion")]
        public IActionResult Converstion(string FromUnit, string ToUnit, double Value)
        {
            try
            {
                TempratureUnit tempratureUnit = new TempratureUnit();
                tempratureUnit.FromUnit = FromUnit;
                tempratureUnit.ToUnit = ToUnit;
                tempratureUnit.Value = Value;

                if (string.IsNullOrEmpty(tempratureUnit.FromUnit) || string.IsNullOrEmpty(tempratureUnit.ToUnit) || tempratureUnit.Value == 0)
                {
                    return BadRequest();
                }

                string value = _unitConverstionService.ConvertByUnit(tempratureUnit);

                return Ok(value);
            }
            catch (Exception)
            {
                return new JsonResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
