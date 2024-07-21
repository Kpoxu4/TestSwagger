﻿using Microsoft.AspNetCore.Mvc;
using Shared.Enum;
using TestSwagger.ApiModel;
using TestSwaggerData.DataModel;
using TestSwaggerData.Interfaces;
using TestSwaggerData.Repositories;

namespace TestSwagger.Controllers
{
    [ApiController]
    [Route("/api/todo")]
    public class ToDoItemController : Controller
    {
        private IUserRepository _userRepository;
        private IPriorityRepository _priorityRepository;
        private IToDoItemRepository _toDoItemRepository;

        public ToDoItemController(IUserRepository userRepository, IPriorityRepository priorityRepository, IToDoItemRepository toDoItemRepository)
        {
            _userRepository = userRepository;
            _priorityRepository = priorityRepository;
            _toDoItemRepository = toDoItemRepository;
        }
        [HttpPost]
        [Route("create")]
        public IActionResult CreateNewToDoItem([FromBody] ToDoItemCreate toDoItem)
        {
            if (toDoItem == null)
            {
                return BadRequest("Invalid input");
            }

            var priority = _priorityRepository.GetPriority(toDoItem.Priority);

            if (priority == null)
            {
                return BadRequest("Priority not found");
            }

            var newtoDoItem = new ToDoItem()
            {
                Title = toDoItem.Title,
                Description = toDoItem.Description,
                IsCompleted = false,
                DueDate = toDoItem.DueDate,
                Priority = priority
            };

            _toDoItemRepository.Create(newtoDoItem);
            _priorityRepository.AddToDoItemInList(priority, newtoDoItem);
            return Ok("Create completed");
        }
    }
}
