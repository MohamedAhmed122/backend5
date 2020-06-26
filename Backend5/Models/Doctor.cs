using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend5.Models
{
    public class Doctor
    {
        public Int32 Id { get; set; }

        public string Name { get; set; }

        public string Specialty { get; set; }

        public ICollection<DoctorHospitel> Hospitels { get; set; }

        public ICollection<DoctorPatient> doctorPatients { get; set; }
    }
}
