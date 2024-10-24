using Common.Dtos;
using Common.Utilities;
using EasyWeb.TicketsMicroservice.Models.Dtos.EntityDto;
using EasyWeb.TicketsMicroservice.Models.Entities;

namespace EasyWeb.TicketsMicroservice.Models.Dtos.ResponseDto
{
    public class ResponseFilterTicketDto : GenericFilterDto
    {
        public ResponseFilterTicketDto()
        {
            this.Tickets = new List<TicketResumeDto>();
            FilterablesFields = Extensions.GetFilterablesFields<Ticket>();
        }

        public List<TicketResumeDto> Tickets { get; set; }
    }
}
