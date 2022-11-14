using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject.Application.Dto.Task
{
    public class TaskRequestDTO
    {
        public Guid uid { get; set; }

        public string Title { get; set; }

        public string Descripton { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsDone { get; set; }
    }
}
