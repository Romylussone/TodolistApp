using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodolistApi.core.Domain.model
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public required string Description { get; set; }
        public bool IsOpened { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
