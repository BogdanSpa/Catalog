using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentFeature.GetStudentsWithNotesOnSubjectCatalogUseCase
{
    public class GetStudentsWithNotesOnSubjectCatalogResponse
    {
        public string Nume { get; set; } = null!;
        public string Prenume { get; set; } = null!;
        public int AnUniversitar { get; set; }
    }
}
