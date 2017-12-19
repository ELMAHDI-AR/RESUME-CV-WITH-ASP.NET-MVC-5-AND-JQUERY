using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ResumeMVC.ViewModels
{
    public class PersonVM
    {
        public int IDPers { get; set; }

        [Required(ErrorMessage = "Please Your First Name ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Your Last Name ")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Your Date Of Birth ")]
        public Nullable<System.DateTime> DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please Your Nationality ")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Select Your Educational Level ")]
        public string EducationalLevel { get; set; }

        [Required(ErrorMessage = "Please Your Address ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Your Phone Number ")]
        public string Tel { get; set; }

        [Required(ErrorMessage = "Please Your Email Address ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Your Summary")]
        [DataType(DataType.MultilineText)]
        public string Summary { get; set; }

        [Required(ErrorMessage = "Please Your LinekedIn Profil")]
        [DataType(DataType.Url)]
        public string LinkedInProdil { get; set; }

        [Required(ErrorMessage = "Please Your Facebook Profil")]
        [DataType(DataType.Url)]
        public string FaceBookProfil { get; set; }

        [Required(ErrorMessage = "Please Your C# Corner Profil")]
        [DataType(DataType.Url)]
        public string C_CornerProfil { get; set; }

        [Required(ErrorMessage = "Please Your Twitter Profil")]
        [DataType(DataType.Url)]
        public string TwitterProfil { get; set; }
        public byte[] Profil { get; set; }

        public List<SelectListItem> ListNationality { get; set; }
        public List<SelectListItem> ListEducationalLevel { get; set; }
    }
}