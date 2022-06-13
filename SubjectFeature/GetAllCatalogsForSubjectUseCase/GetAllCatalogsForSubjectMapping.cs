using AutoMapper;
using EFORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectFeature.GetAllCatalogsForSubjectUseCase
{
    public class GetAllCatalogsForSubjectMapping : Profile
    {
        public GetAllCatalogsForSubjectMapping()
        {
            CreateMap<GetAllCatalogsForSubjectResponse, Catalog>().ReverseMap();
        }
    }
}
