using Order.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Business.Abstract
{
    public interface ISendMailService
    {
        void AddMailtoQueue(RabbitMailTemplate mailTemplate);
        Task SendMailQueue(string queueName);
    }
}
