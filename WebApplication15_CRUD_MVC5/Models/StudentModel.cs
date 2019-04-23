using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication15_CRUD_MVC5.Models
{
    public class StudentModel
    {
        [Display(Name="Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Address { get; set; }
    }
}