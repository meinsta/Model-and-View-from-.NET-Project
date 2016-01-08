using Phobos.Models.Jobs.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Phobos.Models.Jobs.Entities
{
    public class JobPosting
    {
        public const int DAYS_TIL_EXPIRATION = 30;

        public JobPosting()
        {

        }

        public int ID { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreateDate { get; set; }

        [NotMapped]
        public DateTime ExpirationDate {
            get
            {
                return CreateDate.AddDays(DAYS_TIL_EXPIRATION);
            }
        }
        [NotMapped]
        public string Active
        {
            get
            {
                if (CreateDate.AddDays(DAYS_TIL_EXPIRATION) >= DateTime.Now.Date)
                {
                    string x = "Active";
                    return x;
                }
                else
                {
                    string y = "Expired";
                    return y;
                }
            }
        }

        public ICollection<JobPostingCategory> Categories { get; set; }

        public ICollection<JobApplication> Applications { get; set; }

        public string Company { get; set; }

        public string ContactName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Fax { get; set; }

        public bool HidePhone { get; set; }

        public bool HideFax { get; set; }

        public bool SendEmailNotification { get; set; }

        [DataType(DataType.Url)]
        public string ApplicationUrl { get; set; }

        [Required(ErrorMessage = "Please enter a Title.")]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int EmployeeType { get; set; }

        [Required]        
        public Jobs.Enums.JobLocation JobLocation { get; set; }

        [Required]
        public int ExperienceRequired { get; set; }

        [Required]
        public int DegreeRequired { get; set; }

        [Required]
        public int TravelRequired { get; set; }

        [Required]
        public string JobRequireDescription { get; set; }

        public int SecurityClearance { get; set; }

        public int ForeignLanguage { get; set; }

        public bool ActivateJob { get; set; }

        public String Compensation { get; set; }

        public String AvgBonusPerYear { get; set; }
        
    }
}