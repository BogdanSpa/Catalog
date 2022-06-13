using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesFeature.AddNoteForStudentUseCase
{
    public class AddNoteForStudentModel
    {
       public int StudentId { get; set; }
       public int MaterieId { get; set; }
       public byte Nota { get; set; }
       public int CatalogId { get; set; }
    }
}
