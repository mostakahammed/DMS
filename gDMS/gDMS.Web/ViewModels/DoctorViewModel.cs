using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gDMS.Web.ViewModels
{
    public class DoctorViewModel
    {
        public int DoctorID { get; set; }

        [Display(Name = "Doctor Name")]
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        public string DoctorName { get; set; }

        [Display(Name = "Degree")]
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        public string DoctorDegree { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(200, ErrorMessage = "Maximum length is {1}")]
        public string DoctorAddress { get; set; }

        [Display(Name = "Phone Number")]
        public int? DoctorPhone { get; set; }

        [Display(Name = "Is Active?")]
        [Required(ErrorMessage = "{0} is Required")]
        public bool IsActive { get; set; }
    }
}