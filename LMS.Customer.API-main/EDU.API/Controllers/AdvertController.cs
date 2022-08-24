using AutoMapper;
using EDU.Core.DTOs;
using EDU.Core.DTOs.AdvertDTOs;
using EDU.Core.Entities;
using EDU.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace EDU.API.Controllers
{
    public class AdvertController:CustomBaseController
    {
        private readonly IService<Advert> _service;
        private readonly IMapper _mapper;

        public AdvertController(IService<Advert> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> All()
        {
            var advert = await _service.GetAllAsync();
            var advertDtos = _mapper.Map<List<GetAdvertDto>>(advert.ToList());
            return Ok(CustomResponseDto<List<GetAdvertDto>>.Success(advertDtos));
        }

        [HttpPost]
        public async Task<IActionResult> Add(SetAdvertDto advertDto)
        {
            var advert = _mapper.Map<Advert>(advertDto);
            await _service.AddAsync(advert);
            return Ok(CustomResponseDto<NoContentDto>.Success());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var advert = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(advert);
            return Ok(CustomResponseDto<NoContentDto>.Success());
        }

        [HttpPut]
        public async Task<IActionResult> Update(GetAdvertDto advertDto)
        {
            var advert = _mapper.Map<GetAdvertDto, Advert>(advertDto);
            advert.UpdatedOn = DateTime.Now;
            await _service.UpdateAsync(advert);
            return Ok(CustomResponseDto<NoContentDto>.Success());
        }
    }
}
