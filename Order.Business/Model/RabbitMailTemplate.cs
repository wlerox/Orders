using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Business.Model
{
    public class RabbitMailTemplate
    {
        public string QueueName;
        public string MailAddress;
        public string Message;
    }
}
