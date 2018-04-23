using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PGS.Kanban.Domain.DTOs
{
    public class AddCardDto
    {
        [Required]
        public int ListId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
