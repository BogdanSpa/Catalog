using EFORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DTOModels
{
    public class CreateNoteModel
    {
        public int StudentId;
        public int MaterieId;
        public byte Nota;
        public DateTime? IssueDate;
        public int CatalogId;
    }
}
