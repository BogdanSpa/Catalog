using System;
using System.Collections.Generic;

namespace EFORM.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Notes = new HashSet<Note>();
            SubjectCatalogs = new HashSet<SubjectCatalog>();
        }

        public int Id { get; set; }
        public string Nume { get; set; } = null!;
        public byte? PredataInAn { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<SubjectCatalog> SubjectCatalogs { get; set; }
    }
}
