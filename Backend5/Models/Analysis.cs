using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend5.Models
{
    public class Analysis
    {
        public Int32 AnalysisId { get; set; }

        public string Type { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }

        public Patient Patient { get; set; }

        public Int32 PatientId { get; set; }

        public ICollection<AnalysisLab> AnalysisLabs { get; set; }
    }
}
