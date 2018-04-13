using System;
using System.Collections.Generic;
using System.Text;

namespace PGS.Kanban.Domain.DTOs
{
    public class DeleteListDto
    {
        public int ListId { get; set; }

        public int BoardId { get; set; }
    }
}
