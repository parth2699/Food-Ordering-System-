using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineFoodOrderingSystem.Models
{
    [Bind(Exclude = "Id")]
    public class EmployeeOrder
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Pleas enter your name")]
        [DisplayName("First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your surname")]
        [DisplayName("Surname")]
        [StringLength(50)]
        public string LastName { get; set; }
       
        [Required(ErrorMessage = "Pls enter email address")]
        [DisplayName("Email Address")]

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
     
        [ScaffoldColumn(false)]
        [Column(TypeName = "datetime2")]
        public DateTime DateCreated { get; set; }

        [ScaffoldColumn(false)]
        public Decimal Amount { get; set; }

        [ScaffoldColumn(false)]
        public string CustomerUserName { get; set; }

    }
}