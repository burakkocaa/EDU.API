using AutoMapper;
using EDU.Core.DTOs;
using EDU.Core.DTOs.RegisterDTOs;
using EDU.Core.Entities;
using EDU.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace EDU.API.Controllers
{
    public class RegisterController:CustomBaseController
    {
        private readonly IRegisterService _service;
        private readonly IMapper _mapper;

        public RegisterController(IMapper mapper, IRegisterService service )
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var register = await _service.GetAllAsync();
            var registerDtos = _mapper.Map<List<GetRegisterDto>>(register.ToList());
            return Ok(CustomResponseDto<List<GetRegisterDto>>.Success(registerDtos));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllWithAdvert()
        {
            return Ok(await _service.GetAllWithAdvertAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Add(SetRegisterDto registerDto)
        {
            var register = _mapper.Map<Register>(registerDto);
            await _service.AddAsync(register);
            return Ok(CustomResponseDto<NoContentDto>.Success());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var register = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(register);
            return Ok(CustomResponseDto<NoContentDto>.Success());
        }

        [HttpPut]
        public async Task<IActionResult> Update(GetRegisterDto registerDto)
        {
            var register = _mapper.Map<GetRegisterDto, Register>(registerDto);
            register.UpdatedOn = DateTime.Now;
            await _service.UpdateAsync(register);
            return Ok(CustomResponseDto<NoContentDto>.Success());
        }
    }
}
