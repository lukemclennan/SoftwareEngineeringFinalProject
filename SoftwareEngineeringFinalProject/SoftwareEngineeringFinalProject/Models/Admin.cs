using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareEngineeringFinalProject.Models
{
    public class Admin
    {
        [PrimaryKey, AutoIncrement]
        public int AdminID { get; set; }
        public string AdminFirstName { get; set; }
        public string AdminLastName { get; set; }
        public string AdminUsername { get; set; }
        public string AdminPassword { get; set; }

    }
}

