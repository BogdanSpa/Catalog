using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentFeature.GetStudentsWithNotesOnSubjectCatalogUseCase
{
    public class GetStudentsWithNotesOnSubjectCatalogRequest
    {
        public int SubjectID { get; set; }
        public int CatalogID { get; set; }
    }
}
