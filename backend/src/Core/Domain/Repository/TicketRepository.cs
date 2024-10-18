using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using TodolistApi.core.Domain.model;
using TodolistApi.core.Infrastructure;
using TodolistApi.Core.Domain.Abstraction;

namespace TodolistApi.Core.Domain.Repository
{
    public class TicketRepository : IBaseRepository<Ticket>, IPaginateRepository<Ticket>
    {
        private readonly TicketDBContext _db;
        public TicketRepository(TicketDBContext db)
        {
            _db = db;
        }

        public async Task<Ticket> Add(Ticket entity)
        {
            _db.Tickets.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var ticket = await TicketExists(id);

            _db.Tickets.Remove(ticket);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await _db.Tickets.ToListAsync();
        }

        public async Task<Ticket> GetById(int id)
        {
            return await TicketExists(id);
        }

        public async Task<IEnumerable<Ticket>> GetByPage(int page, int limit)
        {
            var position = (page - 1) * limit;
            var result = await _db.Tickets.OrderBy(t => t.Id).Skip(position).Take(limit).ToListAsync();

            return result;
        }

        public async Task<int> GetTotalPage(int limit)
        {
            var nbElems = await _db.Tickets.CountAsync();

            return (int)Math.Ceiling((double)nbElems / limit);
        }

        public async Task<Ticket> Update(Ticket entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return entity;

            //try
            //{
                
            //}
            //catch (DbUpdateConcurrencyException)
            //{

            //}
        }

        private async Task<Ticket> TicketExists(int id)
        {
            var ticket = await _db.Tickets.FindAsync(id);

            if (ticket == null)
            {
                throw new Exception("Ticket not found");
            }

            return ticket;
        }
    }
}
