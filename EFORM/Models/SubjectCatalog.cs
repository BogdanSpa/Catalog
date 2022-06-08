using System;
using System.Collections.Generic;

namespace EFORM.Models
{
    public partial class SubjectCatalog
    {
        public int? MaterieId { get; set; }
        public int? CatalogId { get; set; }
        public int Id { get; set; }

        public virtual Catalog? Catalog { get; set; }
        public virtual Subject? Materie { get; set; }
    }
}
