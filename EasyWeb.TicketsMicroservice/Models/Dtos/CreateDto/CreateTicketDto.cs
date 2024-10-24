using EasyWeb.TicketsMicroservice.Models.Dtos.EntityDto;

namespace EasyWeb.TicketsMicroservice.Models.Dtos.CreateDto
{
    public class CreateTicketDto
    {
        public CreateTicketDataDto TicketDto { get; set; }
        public TicketMessageDto MessageDto { get; set; }

        public CreateTicketDto()
        {
            this.TicketDto = new CreateTicketDataDto();
            this.MessageDto = new TicketMessageDto();
        }
        public CreateTicketDto(CreateTicketDataDto ticket, TicketMessageDto message)
        {
            this.TicketDto = ticket;
            this.MessageDto = message;
        }
    }
}
