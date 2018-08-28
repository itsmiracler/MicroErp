﻿using MementoFX;
using MementoFX.Domain;
using OnTime.TaskManagement.CommandStack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTime.TaskManagement.CommandStack.Events
{
    public class TaskAddedEvent : DomainEvent
    {
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }

        [Timestamp]
        public DateTime DateOfCreation { get; set; }

        public string TaskName { get; set; }

        public TaskPriority Priority { get; set; }
    }
}
