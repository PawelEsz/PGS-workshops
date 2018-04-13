using PGS.Kanban.Domain.DTOs;
using PGS.Kanban.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PGS.Kanban.Domain.DTOS
{
    public class BoardDto
    {
        public BoardDto()
        {
            Lists = new List<ListDto>();
        }

        public int Id { get; set; }

        public string Name { get; set; }
        
        public List<ListDto> Lists { get; set; }
    }
}
