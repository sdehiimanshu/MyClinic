using Microsoft.AspNetCore.Mvc;
using MyClinic.Application.DTOs;
using MyClinic.Application.Interfaces;

namespace MyClinic.Web.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // GET
        [HttpGet]
        public IActionResult Appointment_Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Appointment_Create(AppointmentDto dto)
        {
            // ✅ STEP 1: Model Validation Check
            if (!ModelState.IsValid)
            {
                // 🔍 Debugging: All errors combine karo
                var errors = ModelState.Values
                                       .SelectMany(v => v.Errors)
                                       .Select(e => e.ErrorMessage)
                                       .ToList();

                TempData["Error"] = string.Join(" | ", errors);

                return View(dto); // ❗ important: same data back
            }

            // ✅ STEP 2: Save via Service Layer
            await _appointmentService.CreateAsync(dto);

            // ✅ STEP 3: Success Message + Redirect (PRG Pattern)
            TempData["Success"] = "Your appointment has been scheduled successfully.";

            return RedirectToAction(nameof(Appointment_Create));
        }
    }
}