using PGS.Kanban.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PGS.Kanban.Domain.DTOs
{
    public class ListDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BoardId { get; set; }
    }
}
