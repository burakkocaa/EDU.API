using EDU.Core.DTOs.AdvertDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Core.DTOs.RegisterDTOs
{
    public class GetRegisterDto:BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public int AdvertId { get; set; }
        public GetAdvertDto Advert { get; set; }
    }
}
