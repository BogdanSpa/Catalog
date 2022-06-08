using System;
using System.Collections.Generic;

namespace EFORM.Models
{
    public partial class Student
    {
        public Student()
        {
            Notes = new HashSet<Note>();
        }

        public int Id { get; set; }
        public string Nume { get; set; } = null!;
        public string Prenume { get; set; } = null!;
        public int AnUniversitar { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}
