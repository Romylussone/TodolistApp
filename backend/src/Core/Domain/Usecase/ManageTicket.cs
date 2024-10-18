using TodolistApi.core.Domain.model;
using TodolistApi.Core.Domain.Abstraction;
using TodolistApi.Core.Domain.Model.Dtos;

namespace TodolistApi.Core.Domain.Usecase
{
    public class ManageTicket
    {
        private readonly IBaseRepository<Ticket> _ticketRepository;
        private readonly IPaginateRepository<Ticket> _paginateTicketRepository;
        public ManageTicket(IBaseRepository<Ticket> ticketRepository, IPaginateRepository<Ticket> paginateTicketRepository)
        {
            _ticketRepository = ticketRepository;
            _paginateTicketRepository = paginateTicketRepository;
        }

        public async Task<Ticket> CreateTicket(TicketDataDto ticketDataDto)
        {
            var ticket = new Ticket
            {
                Description = ticketDataDto.Description,
                IsOpened = ticketDataDto.IsOpened,
                CreatedAt = DateTime.Now
            };
            await _ticketRepository.Add(ticket);
            return ticket;
        }

        public async Task<Ticket> UpdateTicket(int id, TicketDataDto ticketDataDto)
        {
            var ticket = await _ticketRepository.GetById(id);
            if(ticket == null)
            {
                throw new Exception("Ticket not found");
            }

            ticket.Description = ticketDataDto.Description;
            ticket.IsOpened = ticketDataDto.IsOpened;
            await _ticketRepository.Update(ticket);
            return ticket;
        }

        public async Task<GetTicketPageDto> GetTicketByPage(int page, int limit)
        {
            var tickets = await _paginateTicketRepository.GetByPage(page, limit);
            var totalPage = await _paginateTicketRepository.GetTotalPage(limit);

            return new GetTicketPageDto
            {
                Tickets = tickets,
                CurrentPage = page,
                TotalPage = totalPage
            };
        } 
    }
}
