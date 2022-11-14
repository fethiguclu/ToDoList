using System;
using TaskProject.Domain.Common;
using TaskProject.Domain.Enumeration;

namespace TaskProject.Domain.Entities
{
    public class Tasks : BaseEntity
    {
        public string Title { get; set; }

        public string Descripton { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsDone { get; set; }

        public TaskStatus? Status { get; set; }
    }
}
