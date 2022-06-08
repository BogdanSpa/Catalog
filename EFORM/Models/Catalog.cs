using System;
using System.Collections.Generic;

namespace EFORM.Models
{
    public partial class Catalog
    {
        public Catalog()
        {
            NoteLists = new HashSet<NoteList>();
            SubjectCatalogs = new HashSet<SubjectCatalog>();
        }

        public int Id { get; set; }
        public string Clasa { get; set; } = null!;
        public bool? Active { get; set; }

        public virtual ICollection<NoteList> NoteLists { get; set; }
        public virtual ICollection<SubjectCatalog> SubjectCatalogs { get; set; }
    }
}
