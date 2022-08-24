using EDU.Core.Entities;
using EDU.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Repository.Repositories
{
    public class RegisterRepository : GenericRepository<Register>, IRegisterRepository
    {
        private readonly DbSet<Register> _dbSet;

        public RegisterRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _dbSet = appDbContext.Set<Register>();
        }
        public async Task<List<Register>> GetAllWithAdvertAsync()
        {
            return await _dbSet.Where(x => !x.IsDeleted).Include(x => x.Advert).ToListAsync();
        }
    }
}
