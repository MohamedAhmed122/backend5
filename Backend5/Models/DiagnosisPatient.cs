using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend5.Models
{
    public class DiagnosisPatient
    {
        public Int32 DiagnosisId { get; set; }

        public Diagnosis Diagnosis { get; set; }

        public int PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}
