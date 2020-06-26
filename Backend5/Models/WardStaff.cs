using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend5.Models
{
    public class WardStaff
    {
        public Int32 StaffId { get; set; }

        public Int32 WardId { get; set; }


        public Ward Ward { get; set; }


        [Required]
        public string Name { get; set; }


        public string Position { get; set; }
    }
}
