using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PGS.Kanban.Domain.Models
{
    public class Board
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        //virtual aby uzyc lazy loading
        public virtual ICollection<List> Lists { get; set; }
    }
}
