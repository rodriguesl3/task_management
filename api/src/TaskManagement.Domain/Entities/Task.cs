using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Domain.Aggregation;

namespace TaskManagement.Domain.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TimeStamp { get; set; }
        public TaskStatus Status { get; set; }
    }
}
