using AutoMapper;
using EFORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentFeature.CrudUsecase
{
    public class CrudMapping : Profile
    {
        public CrudMapping()
        {
            CreateMap<StudentModel, Student>().ReverseMap();
        }
    }
}
