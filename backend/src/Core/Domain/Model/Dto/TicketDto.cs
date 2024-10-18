using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TodolistApi.core.Domain.model;

namespace TodolistApi.Core.Domain.Model.Dtos
{
    public class TicketDataDto
    {
        [Required]
        public required string Description { get; set; }
        public bool IsOpened { get; set; } = false;
    }

    public class GetTicketPageDto
    {
        public IEnumerable<Ticket>? Tickets { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
    }
}
