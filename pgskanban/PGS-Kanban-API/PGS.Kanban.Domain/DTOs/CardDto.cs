using System;
using System.Collections.Generic;
using System.Text;

namespace PGS.Kanban.Domain.DTOs
{
    public class CardDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ListId { get; set; }

    }
}
