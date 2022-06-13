using AutoMapper;
using EFORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogFeature.GetSubjectsForCatalogUseCase
{
    public class GetSubjectForCatalogMapping : Profile
    {
        public GetSubjectForCatalogMapping()
        {
            CreateMap<GetSubjectForCatalogResponse, Subject>().ReverseMap();
        }
    }
}
