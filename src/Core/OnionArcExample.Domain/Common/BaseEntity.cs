using System;
using System.Collections.Generic;
using System.Text;

namespace TaskProject.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public Guid uid { get; set; }

        public int? CreatedUserId { get; set; }

        public int? ModifiedUserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
