using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [Display(Name = "Enter your name")]
        [StringLength(25)]
        [Required(ErrorMessage = "Name length must be at leas 3 symbols")]
        public string Name { get; set; }
        [Display(Name = "Enter your surname")]
        [StringLength(25)]
        [Required(ErrorMessage = "Surname length must be at leas 5 symbols")]
        public string SurName { get; set; }
        [Display(Name = "Enter your adress")]
        [StringLength(35)]
        [Required(ErrorMessage = "Adress length must be at leas 3 symbols")]
        public string Adress { get; set; }
        [Display(Name = "Enter your phone number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        [Required(ErrorMessage = "Phone length must be at leas 10 symbols")]
        public string Phone { get; set; }
        [Display(Name = "Enter your email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(25)]
        [Required(ErrorMessage = "Email length must be at leas 10 symbols")]
        public string Email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
