using System;
using System.Collections.Generic;
using System.Text;

namespace PGS.Kanban.Domain.DTOs
{
    public class EditListNameDto
    {
        public string Name { get; set; }

        public int ListId { get; set; }

        public int BoardId { get; set; }

    }
}
