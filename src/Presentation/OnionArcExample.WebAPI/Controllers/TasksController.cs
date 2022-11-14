using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskProject.Application.Dto.Task;
using TaskProject.Application.Interfaces.Repositories;
using TaskProject.Application.Interfaces.Services;
using TaskProject.Domain.Entities;

namespace TaskProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        readonly ITaskRepository _TasksRepository;
        readonly IEmailService _emailService;
        public TasksController(IEmailService emailService, ITaskRepository tasksRepository)
        {

            _emailService = emailService;
            _TasksRepository = tasksRepository;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            List<Tasks> allTasks = await _TasksRepository.GetAll();
            return Ok(allTasks);
        }

        [HttpGet("GetPending")]
        public async Task<IActionResult> GetPending()
        {
            List<Tasks> allTasks = (await _TasksRepository.GetAll()).Where(x => x.EndDate < System.DateTime.Now && !x.IsDone).ToList();
            return Ok(allTasks);
        }

        [HttpGet("GetOverdue")]
        public async Task<IActionResult> GetOverdue()
        {
            List<Tasks> allTasks = (await _TasksRepository.GetAll()).Where(x => x.EndDate > System.DateTime.Now && !x.IsDone).ToList();
            return Ok(allTasks);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TaskRequestDTO request)
        {
            var task = request.Adapt(new Tasks());
            task = await _TasksRepository.Add(task);
            var response = task.Adapt<TaskResponseDTO>();
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TaskRequestDTO request)
        {
            var task = request.Adapt<Tasks>();
            task = await _TasksRepository.Update(task);
            var response = task.Adapt<TaskResponseDTO>();
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove([FromBody] TaskRequestDTO request)
        {
            var task = await _TasksRepository.Remove(request.uid);
            var response = task.Adapt<TaskResponseDTO>();
            return Ok(response);
        }
    }
}
