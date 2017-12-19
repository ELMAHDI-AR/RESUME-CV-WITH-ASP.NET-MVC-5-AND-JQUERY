using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeMVC.ViewModels
{
    public class WorkExperienceVM
    {
        public int IDExp { get; set; }

        [Required(ErrorMessage ="Please Your Company")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Please Your Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Country is required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter Start Date")]
        public Nullable<System.DateTime> FromYear { get; set; }

        [Required(ErrorMessage = "Please enter End Date")]
        public Nullable<System.DateTime> ToYear { get; set; }
        
        [Required(ErrorMessage = "Please enter Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public List<SelectListItem> ListeOfCountries { get; set; }


    }
}