using System;
using System.Collections.Generic;

namespace EFORM.Models
{
    public partial class NoteList
    {
        public int NotaId { get; set; }
        public int CatalogId { get; set; }
        public int Id { get; set; }

        public virtual Catalog Catalog { get; set; } = null!;
        public virtual Note Nota { get; set; } = null!;
    }
}
