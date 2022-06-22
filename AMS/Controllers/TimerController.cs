using AMS.Repository;
using AMS.web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http.Headers;
using System.Timers;
namespace AMS.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TimerController : Controller
    {
    private static ITimerService _context;
    private static System.Timers.Timer aTimer;
        public TimerController(ITimerService context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> getAllKaryakar()
        {
            //Console.WriteLine("Hey Started");
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 86400;
            aTimer.Elapsed += hey;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            return Ok(await _context.AddDate());
        }     

        public async static void hey(Object source, System.Timers.ElapsedEventArgs e)
        {
            //Console.WriteLine("Hey 2 sec");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7140/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/Timer/getQuery");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Sucess...");
            }
        }

        [HttpGet]
        public async Task<IActionResult> getQuery()
        {
            //Console.WriteLine("Hey Started 1");
            return Ok(await _context.AddDate());
        }

    }
}
