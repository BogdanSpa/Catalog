using AutoMapper;
using EFORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectFeature.AddSubjectToCatalogUseCase
{
    public class AddSubjectToCatalogMapping : Profile
    {
        public AddSubjectToCatalogMapping()
        {
            CreateMap<AddSubjectToCatalogModel, SubjectCatalog>().ReverseMap();
        }
    }
}
