using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Net.Mail;
using OA.Entites;
using OA.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.AllEventBus
{
    /// <summary>
    /// 后台工作实体
    /// </summary>
    [Serializable]
    public class SimpleSendEmailJobArgs
    {
        public int SenderUserId { get; set; }

        public int TargetUserId { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
    /// <summary>
    /// 后台工作
    /// </summary>
    public class SimpleSendEmailJob : BackgroundJob<SimpleSendEmailJobArgs>, ITransientDependency
    {
        private readonly IRepository<Q_UserInfo> _userRepository;
        private readonly IEmailSender _emailSender;

        public SimpleSendEmailJob(IRepository<Q_UserInfo> userRepository, IEmailSender emailSender)
        {
            _userRepository = userRepository;
            _emailSender = emailSender;
        }

        public override void Execute(SimpleSendEmailJobArgs args)
        {
            string from = args.SenderUserId > 0 ? "274852528@qq.com" : "";
            string toem = args.TargetUserId > 0 ? "495614852@qq.com" : "";
           // _emailSender.Send(from, toem, args.Subject, args.Body);
        }
    }
}
