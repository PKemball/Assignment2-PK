using Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class BaseType : Entity
    {
        public Status Status { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public BaseType(Status status,string name,string description)
        {
            Status = status;
            Name = name;
            Description = description;
        }

    }
}
