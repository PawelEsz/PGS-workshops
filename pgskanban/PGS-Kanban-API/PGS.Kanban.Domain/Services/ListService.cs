﻿using PGS.Kanban.Domain.DTOs;
using PGS.Kanban.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PGS.Kanban.Domain.Services
{
    public class ListService
    { 
        private readonly KanbanContext _context;

        public ListService()
        {
            _context = new KanbanContext();
        }

        public ListDto AddList(AddListDto addListDto)
        {
            if(!_context.Boards.Any(x => x.Id == addListDto.BoardId))
            {
                return null;
            }

            //????????
            var list = new List
            {
                Name = addListDto.Name,
                BoardId = addListDto.BoardId
            };

            _context.Lists.Add(list);
            _context.SaveChanges();

            var listDto = new ListDto
            {
                Id = list.Id,
                BoardId = list.BoardId,
                Name = list.Name
            };

            return listDto;
        }

        public bool EditListName(EditListNameDto editListNameDto)
        {
            if (!_context.Boards.Any(x => x.Id == editListNameDto.BoardId))
            {
                return false;
            }

            var list = _context.Lists.SingleOrDefault(l => l.Id == editListNameDto.ListId);

            if(list == null || list.Name == editListNameDto.Name)
            {
                return false;
            }

            list.Name = editListNameDto.Name;

            //zwraca ilosc zmodyfikowanych rekordow
            var result = _context.SaveChanges();

            return result > 0;
        }

        public bool DeleteList(DeleteListDto deleteListDto)
        {
            if(!_context.Boards.Any(x => x.Id == deleteListDto.BoardId))
            {
                return false;
            }

            var list = _context.Lists.SingleOrDefault(l => l.Id == deleteListDto.ListId);

            if(list == null)
            {
                return false;
            }

            _context.Lists.Remove(list);

            var result =_context.SaveChanges();

            return result > 0;
        }
    }
}
