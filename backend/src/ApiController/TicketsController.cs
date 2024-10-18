using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodolistApi.core.Domain.model;
using TodolistApi.core.Infrastructure;
using TodolistApi.Core.Domain.Abstraction;
using TodolistApi.Core.Domain.Model.Dtos;
using TodolistApi.Core.Domain.Repository;
using TodolistApi.Core.Domain.Usecase;

namespace TodolistApi.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly TicketDBContext _context;
        private readonly IBaseRepository<Ticket> _ticketRepository;
        private readonly ManageTicket _manageTicket;

        public TicketsController(TicketDBContext context)
        {
            _context = context;
            _ticketRepository = new TicketRepository(context);
            _manageTicket = new ManageTicket(_ticketRepository, new TicketRepository(context));
        }

        // GET: api/Tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        {
            return Ok(await _ticketRepository.GetAll());          
        }

        // GET: api/Tickets/page/1/limit/10
        [Route("page/{page}/limit/{limit}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicketsByPage(int page, int limit)
        {
            return Ok(await _manageTicket.GetTicketByPage(page, limit));
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            return Ok(await _ticketRepository.GetById(id));
        }

        // PUT: api/Tickets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, TicketDataDto ticket)
        {
            return Ok(await _manageTicket.UpdateTicket(id, ticket));
        }

        // POST: api/Tickets
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(TicketDataDto ticket)
        {
            return Ok(await _manageTicket.CreateTicket(ticket));
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            return Ok(await _ticketRepository.Delete(id));
        }

    }
}
