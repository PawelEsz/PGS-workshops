using Microsoft.EntityFrameworkCore;
using PGS.Kanban.Domain.DTOs;
using PGS.Kanban.Domain.DTOS;
using PGS.Kanban.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PGS.Kanban.Domain.Services
{
    public class BoardService
    {
        private readonly KanbanContext _context;

        public BoardService()
        {
            _context = new KanbanContext();
        }

        public BoardDto GetBoard()
        {
            var board = _context.Boards
                .Include(b => b.Lists)
                .LastOrDefault();

            if (board == null)
                return null;

            var boardDto = new BoardDto()
            {
                Id = board.Id,
                Name = board.Name,
                Lists = board.Lists.Select(l => new ListDto()
                {
                    Id = l.Id,
                    BoardId = l.BoardId,
                    Name = l.Name
                }).ToList()
            };

            return boardDto;
        }

        public BoardDto CreateBoard(CreateBoardDto createBoardDto)
        {
            var board = new Board()
            {
                Name = createBoardDto.Name
            };

            _context.Boards.Add(board);
            _context.SaveChanges();

            var boardDto = new BoardDto()
            {
                Id = board.Id,
                Name = board.Name
            };

            return boardDto;
        }

        

        //public void AddBoard(BoardDto boardDto)
        //{
        //    var board = new Board()
        //    {
        //        Name = boardDto.Name,
        //        Lists = boardDto.Lists.Select(l => new List()
        //        {
        //            Id = l.Id,
        //            BoardId = l.BoardId,
        //            Name = l.Name
        //        }).ToList()
        //    };

        //    _context.Boards.Add(board);
        //    _context.SaveChanges();
        //}

        //public void DeleteBoard(string name)
        //{
        //    var board = _context.Boards.Where(i => i.Name == "ToDo").FirstOrDefault(); //FirstOrDefault();

        //    _context.Remove(board);
        //    _context.SaveChanges();
        //}
    }
}
