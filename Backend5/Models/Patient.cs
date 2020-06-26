using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend5.Models
{
    public class Patient
    {
        public int PatientId { get; set; }

        public string PatientName { get; set; }

        public string Address { get; set; }

        public DateTime Birthday { get; set; }

        public string Gender { get; set; }

        public ICollection<DoctorPatient> doctorPatients { get; set; }
        public ICollection<Analysis> Analyses { get; set; }
        public ICollection<Diagnosis> Diagnoses { get; set; }
        public ICollection<Placement> Placements { get; set; }
        public ICollection<DiagnosisPatient> DiagnosisPatients { get; set; }



    }
}
