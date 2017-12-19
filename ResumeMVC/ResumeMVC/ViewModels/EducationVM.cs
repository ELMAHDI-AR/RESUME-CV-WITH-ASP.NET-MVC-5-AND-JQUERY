using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ResumeMVC.ViewModels
{
    public class EducationVM
    {

        public int IDEdu { get; set; }

        [Required(ErrorMessage = "Please Your Institute or university")]
        public string InstituteUniversity { get; set; }

        [Required(ErrorMessage = "Please Your Title of diploma")]
        public string TitleOfDiploma { get; set; }

        [Required(ErrorMessage = "Please Your Degree")]
        public string Degree { get; set; }

        [Required(ErrorMessage = "Please enter Start Year")]
        public Nullable<System.DateTime> FromYear { get; set; }

        [Required(ErrorMessage = "Please enter End Year")]
        public Nullable<System.DateTime> ToYear { get; set; }
        [Required(ErrorMessage = "Please enter City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter Country")]
        public string Country { get; set; }

        public List<SelectListItem> ListOfCountry { get; set; }
        public List<SelectListItem> ListOfCity { get; set; }


    }
}