using AutoMapper;
using EFORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesFeature.AddNoteForStudentUseCase
{
    public class AddNoteForStudentMapping : Profile
    {
        public AddNoteForStudentMapping()
        {
            CreateMap<AddNoteForStudentModel, Note>().ReverseMap();
        }
    }
}
