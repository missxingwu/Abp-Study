﻿using Abp.Events.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.AllEventBus
{
    public class TaskCompletedEventData : EventData
    {
        public int TaskId { get; set; }
    }
}
