using AutoMapper;
using EFORM.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogFeature.CrudUsecase
{
    public class CatalogService : ICatalogService
    {
        private readonly CatalogHomeworkContext _context;
        private readonly ILogger<CatalogService> _logger;
        private readonly IMapper _mapper;

        public CatalogService(CatalogHomeworkContext context, ILogger<CatalogService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public bool CreateCatalog(CatalogModel model)
        {
            if (model == null)
                return false;

            var catalog = _mapper.Map<Catalog>(model);

            try
            {
                _context.Catalogs.Add(catalog);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Catalog cant be added error: {ex}");
                return false;
            }
        }

        public Catalog GetCatalog(int id)
        {
            return _context.Catalogs.FirstOrDefault(c => c.Id == id);
        }

        public Catalog GetCatalog(string clasa)
        {
            return _context.Catalogs.FirstOrDefault(c => c.Clasa == clasa);
        }
        public bool RemoveCatalog(int id)
        {
            var catalog = GetCatalog(id);

            try
            {
                if (catalog != null)
                {
                    _context.Catalogs.Remove(catalog);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public bool UpdateCatalog(Catalog catalog)
        {
            var catalogToBeUpdated = _context.Catalogs.FirstOrDefault(c => c.Id == catalog.Id);

            try
            {
                if (catalogToBeUpdated != null)
                {
                    _context.Catalogs.Update(catalogToBeUpdated);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }

            return false;
        }


    }
}
