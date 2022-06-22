using AutoMapper;
using EFORM.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> CreateCatalog(CatalogModel model)
        {
            if (model == null)
                return false;

            var catalog = _mapper.Map<Catalog>(model);

            try
            {
                await _context.Catalogs.AddAsync(catalog);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Catalog cant be added error: {ex}");
                return false;
            }
        }

        public async Task<Catalog> GetCatalogById(int id)
        {
            return await _context.Catalogs.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Catalog> GetCatalogByClass(string clasa)
        {
            return await _context.Catalogs.FirstOrDefaultAsync(c => c.Clasa == clasa);
        }
        public async Task<bool> RemoveCatalog(int id)
        {
            var catalog = await GetCatalogById(id);

            try
            {
                if (catalog != null)
                {
                    _context.Catalogs.Remove(catalog);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public async Task<bool> UpdateCatalog(Catalog catalog)
        {
            var catalogToBeUpdated = await GetCatalogById(catalog.Id);

            try
            {
                if (catalogToBeUpdated != null)
                {
                    _context.Catalogs.Update(catalogToBeUpdated);
                    await _context.SaveChangesAsync();
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
