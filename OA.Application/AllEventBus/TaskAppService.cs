using Abp.Application.Services;
using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Events.Bus;
using OA.Entites;
using OA.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.AllEventBus
{
    public class TaskAppService : ApplicationService
    {
        public IEventBus EventBus { get; set; }

        public TaskAppService()
        {
            EventBus = NullEventBus.Instance;
        }

        public void CompleteTask(Q_UserInfo add)
        {
            //TODO: 完成task的数据库操作...
            EventBus.Trigger(new TaskCompletedEventData { TaskId = 42 });
        }
    }

    public class TestJob : BackgroundJob<int>, ITransientDependency
    {
        public override void Execute(int number)
        {
            Logger.Debug(number.ToString());
        }
    }


}
