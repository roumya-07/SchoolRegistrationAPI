using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegistrationAPI.Models
{
    public class SchoolRegistrationEntity
    {
        [Key]
        public int SchoolID { get; set; } = 0;
        [Required]
        public string SchoolName { get; set; } = null;
        [Required]
        public int StateID { get; set; } = 0;
        [Required]
        public int DistrictID { get; set; } = 0;
        [Required]
        public int SchoolTypeID { get; set; } = 0;
        [Required]
        public string SchoolLevel { get; set; } = null;
        [Required]
        public string SchoolPhoto { get; set; } = null;

        [NotMapped]
        public string StateName { get; set; } = null;

        [NotMapped]
        public string DistrictName { get; set; } = null;
        [NotMapped]
        public string SchoolTypeName { get; set; } = null;
    }
    public class State
    {
        [Key]
        public int StateID { get; set; } = 0;
        [Required]
        public string StateName { get; set; } = null;
    }
    public class District
    {
        [Key]
        public int DistrictID { get; set; } = 0;
        [Required]
        public int StateID { get; set; } = 0;
        [Required]
        public string DistrictName { get; set; } = null;
    }

    public class SchoolType
    {
        [Key]
        public int SchoolTypeID { get; set; } = 0;
        [Required]
        public string SchoolTypeName { get; set; } = null;
    }
}

