using EFORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DTOModels
{
    public class CreateStudentWithNotesModel
    {
        public string Nume;
        public string Prenume;
        public int AnUniversitar;

        public  ICollection<Note> Notes;
    }
}
