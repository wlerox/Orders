using Order.Business.Abstract;

namespace Order.Api.BackgroundService
{
    public class MailSenderBackgroundService : IHostedService
    {
        private readonly ISendMailService _sendMailService;
        private readonly ILogger<MailSenderBackgroundService> _logger;

        public MailSenderBackgroundService(ISendMailService sendMailService,ILogger<MailSenderBackgroundService> logger)
        {
            _sendMailService = sendMailService;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Background mail service started");
            _sendMailService.SendMailQueue("sendMail");
            
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Background mail service stoped");
            throw new NotImplementedException();
        }
    }
}
