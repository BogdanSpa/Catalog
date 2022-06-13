using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EFORM.Models;

namespace CatalogFeature.GetStudentsByCatalogUseCase
{
    public class GetStudentsByCatalogMapping : Profile
    {
        public GetStudentsByCatalogMapping()
        {
            CreateMap<GetStudentsByCatalogResponse, Student>().ReverseMap();
        }
    }
}
