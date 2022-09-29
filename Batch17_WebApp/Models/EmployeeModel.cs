using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Batch17_WebApp.Models
{
    [Table("tbl_Employee")]
    [Index(nameof(Email),IsUnique =true)]
    public class EmployeeModel
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="Provide Employee Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Provide Employee Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Provide Employee Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        [EnumDataType(typeof(Status))]
        [Required(ErrorMessage = "Provide Status")]
        [DataType(DataType.Text)]
        public Status Status { get; set; }
    }

    public enum Status
    {
        Active,
        Inactive
    }
}
