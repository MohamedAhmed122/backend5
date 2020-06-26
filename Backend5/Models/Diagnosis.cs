using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend5.Models
{
    public class Diagnosis
    {
        public Int32 DiagnosisId { get; set; }

        public Int32 PatientId { get; set; }

        public Patient Patient { get; set; }

        public string Type { get; set; }

        public string Complication { get; set; }

        public string Detials { get; set; }
        public ICollection<DiagnosisPatient> DiagnosisPatients { get; set; }

    }
}
