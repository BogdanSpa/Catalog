using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogFeature.GetAverageForEachSubjectUsecase
{
    public class GetAverageForEachSubjectModel
    {
        public string Student { get; set; }

        public string Subject { get; set; }
        public double Average { get; set; }
        //public List<string> Subjects;
        //public List<double> Summaries;

    }
}
