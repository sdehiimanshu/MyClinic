using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClinic.Domain.Enums;

namespace MyClinic.Application.DTOs
{
    public class AppointmentDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public DepartmentType Department { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public string DoctorName { get; set; } = null!;

        public string? Message { get; set; }
    }
}