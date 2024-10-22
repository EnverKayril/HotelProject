using HotelProject.WebUI.DTOs.BookingDTO;
using HotelProject.WebUI.DTOs.ServiceDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5204/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ApprovedReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var bookingUpdate = new ApprovedReservationDTO
            {
                BookingId = id,
                Status = "Onaylandı"
            };

            var jsonData = JsonConvert.SerializeObject(bookingUpdate);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("http://localhost:5204/api/Booking/UpdateReservationStatus", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "BookingAdmin");
            }
            else
            {
                var errorContent = await responseMessage.Content.ReadAsStringAsync();
                TempData["ErrorMessage"] = $"Hata: {errorContent}";
                Console.WriteLine($"API Hatası: {errorContent}");
                return RedirectToAction("Index", "BookingAdmin");
            }
        }
    }
}
