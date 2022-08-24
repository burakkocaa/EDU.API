using AutoMapper;
using EDU.Core.DTOs;
using EDU.Core.DTOs.RegisterDTOs;
using EDU.Core.Entities;
using EDU.Core.Repositories;
using EDU.Core.Services;
using EDU.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Service.Services
{
    public class RegisterService : Service<Register>, IRegisterService
    {
        private readonly IRegisterRepository _repository;
        private readonly IMapper _mapper;
        public RegisterService(IGenericRepository<Register> registerRepository, IUnitOfWork unitOfWork, IRegisterRepository repository, IMapper mapper):base(registerRepository,unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<GetRegisterDto>>> GetAllWithAdvertAsync()
        {
            var register = await _repository.GetAllWithAdvertAsync();
            var registerDtos = _mapper.Map<List<GetRegisterDto>>(register.ToList());
            return CustomResponseDto<List<GetRegisterDto>>.Success(registerDtos);
        }
    }
}
