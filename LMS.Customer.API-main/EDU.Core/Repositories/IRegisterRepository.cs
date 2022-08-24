using EDU.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Core.Repositories
{
    public interface IRegisterRepository
    {
        Task<List<Register>> GetAllWithAdvertAsync();
    }
}
