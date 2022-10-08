using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Batch17_WebApp.Models
{
    [Table("Tbl_Salaray")]
    public class SalaryModel
    {
        //public SalaryModel()
        //{
        //    Employee.ID = EmpID;
        //}
        [Key]
        public int ID { get; set; }
        public DateTime PayrunDate { get; set; }
        public string Status { get; set; }
        //public int EmpID { get; set; }
        public EmployeeModel Employee { get; set; }
    }
}
