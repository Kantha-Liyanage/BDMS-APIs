using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;

namespace BDMS_APIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommonController : ControllerBase
    {
        [HttpGet("Cities")]
        public ActionResult Cities()
        {
            using (var client = new HttpClient())
            {
                var requestJSON = new
                {
                    country = "sri lanka"
                };
                var response = client.PostAsJsonAsync("https://countriesnow.space/api/v0.1/countries/cities", requestJSON).Result;
                if (response.IsSuccessStatusCode)
                {
                    // by calling .Result you are synchronously reading the result
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    return Ok(responseString);
                }
            }

            return BadRequest();
        }
    }
}