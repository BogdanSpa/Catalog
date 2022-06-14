using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EFORM.Models;

namespace CatalogFeature.CrudUsecase
{
    public class CrudMapping : Profile
    {
        public CrudMapping()
        {
            CreateMap<CatalogModel, Catalog>().ReverseMap();
        }
    }
}
