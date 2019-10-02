using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsdaPricingAdministrationTool.Models
{
    [Table("Delivery_Status", Schema = "ops")]
    public class Delivery_Status
    {
     [Key]
     public Int16 TaskOrder { get; set; }
     public string Delivery { get; set; }
     public string TaskName { get; set; }
     public string TaskStatus { get; set; }
     public string TaskDesc { get; set; }
     public DateTime? DateTime { get; set; }
     public string TaskNotes { get; set; }
    }
    [Table("Parameters", Schema = "ops")]
    public class Parameters
    {
        [Key]
        public int PID { get; set; }
        public string ParamName { get; set; }
        public string ParamValue { get; set; }
        public string ParamDesc { get; set; }
        public DateTime? DateTime { get; set; }
    }
    [Table("Delivery_Status_History", Schema = "ops")]
    public class Delivery_Status_History
    {
        [Key]
        public Int16 TaskOrder { get; set; }
        public string Delivery { get; set; }
        public string TaskName { get; set; }
        public string TaskStatus { get; set; }
        public string TaskDesc { get; set; }
        public DateTime? DateTime { get; set; }
        public string TaskNotes { get; set; }
    }
}





