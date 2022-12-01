using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace gDMS.Web.Models
{
    [Table("Doctors")]
    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string DoctorDegree { get; set; }
        public string DoctorAddress { get; set; }
        public int? DoctorPhone { get; set; }
        public bool IsActive { get; set; }
    }
}