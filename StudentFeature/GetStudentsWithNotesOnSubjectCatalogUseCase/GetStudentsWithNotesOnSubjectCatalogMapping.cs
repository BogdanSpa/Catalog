using AutoMapper;
using EFORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentFeature.GetStudentsWithNotesOnSubjectCatalogUseCase
{
    public class GetStudentsWithNotesOnSubjectCatalogMapping : Profile
    {
        public GetStudentsWithNotesOnSubjectCatalogMapping()
        {
            CreateMap<GetStudentsWithNotesOnSubjectCatalogResponse, Student>().ReverseMap();
        }
    }
}
