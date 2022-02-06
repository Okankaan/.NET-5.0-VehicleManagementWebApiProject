using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMDataAccess.Abstract.Repositories;
using VMEntities.VMDBEntities;

namespace VMDataAccess.Concrete.RepositoryImplementations
{
    public class BrandDal:BaseEntityRepository<Brand,VMDBContext>,IBrandDal
    {
        public async Task<List<Brand>>GetAllModelsOfBrands()
        {
            using (VMDBContext context = new VMDBContext())
            {
                return await context.Brands.Include(x => x.Models).ToListAsync();
            }
        }
    }
}
