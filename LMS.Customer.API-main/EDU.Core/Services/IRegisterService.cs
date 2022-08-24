using EDU.Core.DTOs;
using EDU.Core.DTOs.RegisterDTOs;
using EDU.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Core.Services
{
    public interface IRegisterService:IService<Register>
    {
        Task<CustomResponseDto<List<GetRegisterDto>>> GetAllWithAdvertAsync();
    }
}
