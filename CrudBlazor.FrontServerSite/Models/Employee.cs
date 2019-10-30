using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudBlazor.FrontServerSite.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName 是必填")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName 是必填")]
        public string LastName { get; set; }
    }
}
