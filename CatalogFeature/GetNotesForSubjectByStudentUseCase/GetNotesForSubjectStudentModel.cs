using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogFeature.GetNotesForSubjectByStudentUseCase
{
    public class GetNotesForSubjectStudentModel
    {
        public List<byte> Notes { get; set; }
        public string Subject { get; set; }
    }
}
