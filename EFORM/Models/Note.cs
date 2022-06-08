using System;
using System.Collections.Generic;

namespace EFORM.Models
{
    public partial class Note
    {
        public Note()
        {
            NoteLists = new HashSet<NoteList>();
        }

        public int Id { get; set; }
        public int StudentId { get; set; }
        public int MaterieId { get; set; }
        public byte Nota { get; set; }
        public DateTime? IssueDate { get; set; }

        public virtual Subject Materie { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
        public virtual ICollection<NoteList> NoteLists { get; set; }
    }
}
