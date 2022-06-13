using AutoMapper;
using EFORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentFeature.GetStudentsByClassUseCase
{
    public class GetStudentsByClassMapping : Profile
    {
        public GetStudentsByClassMapping()
        {
            CreateMap<GetStudentsByClassResponse, Student>().ReverseMap();
        }
    }
}
