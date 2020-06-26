using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend5.Models
{
    public class AnalysisLab
    {
        public Int32 AnalysisId { get; set; }

        public Analysis Analysis { get; set; }

        public Int32 LabId { get; set; }

        public Lab Lab { get; set; }
    }
}
