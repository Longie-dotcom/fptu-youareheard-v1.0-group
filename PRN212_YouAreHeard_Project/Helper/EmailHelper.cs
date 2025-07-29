
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Net;
using System.Net.Mail;

namespace Helper
{
    public class EmailHelper
    {
        private readonly EmailSettings _settings;

        public EmailHelper()
        {
            _settings = LoadEmailSettings();
        }

        private EmailSettings LoadEmailSettings()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var section = configuration.GetSection("EmailSettings");

            var settings = new EmailSettings
            {
                From = section["From"],
                DisplayName = section["DisplayName"],
                SmtpHost = section["SmtpHost"],
                SmtpPort = int.Parse(section["SmtpPort"]),
                Username = section["Username"],
                Password = section["Password"],
                EnableSSL = bool.Parse(section["EnableSSL"] ?? "true")
            };

            return settings;
        }

        public async Task SendDoctorAccountEmailAsync(string toEmail, string password)
        {
            var fromAddress = new MailAddress(_settings.From, _settings.DisplayName);
            var toAddress = new MailAddress(toEmail);

            var smtp = new SmtpClient
            {
                Host = _settings.SmtpHost,
                Port = _settings.SmtpPort,
                EnableSsl = _settings.EnableSSL,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_settings.Username, _settings.Password)
            };

            string subject = "Chào mừng đến với YouAreHeard - Tài khoản bác sĩ đã được tạo";
            string loginUrl = "https://youareheard.life/login";

            string htmlBody = $@"
            <!DOCTYPE html>
            <html>
            <head>
              <meta charset='UTF-8'>
              <title>Tài khoản bác sĩ được tạo</title>
              <style>
                body {{
                  font-family: Arial, sans-serif;
                  background-color: #f4f4f4;
                  margin: 0;
                  padding: 0;
                }}
                .container {{
                  max-width: 600px;
                  margin: 40px auto;
                  background-color: #ffffff;
                  border-radius: 8px;
                  padding: 30px;
                  box-shadow: 0 0 8px rgba(0,0,0,0.1);
                }}
                .header {{
                  text-align: center;
                  margin-bottom: 20px;
                }}
                .header h1 {{
                  color: #2d3748;
                }}
                .content {{
                  color: #4a5568;
                  font-size: 16px;
                  line-height: 1.6;
                }}
                .info-box {{
                  background-color: #edf2f7;
                  padding: 15px;
                  border-radius: 6px;
                  margin: 15px 0;
                }}
                .login-button {{
                  display: block;
                  width: fit-content;
                  margin: 20px auto;
                  padding: 12px 24px;
                  background-color: #2b6cb0;
                  color: #fff;
                  text-decoration: none;
                  border-radius: 6px;
                  font-weight: bold;
                }}
                .footer {{
                  text-align: center;
                  font-size: 13px;
                  color: #a0aec0;
                  margin-top: 30px;
                }}
              </style>
            </head>
            <body>
              <div class='container'>
                <div class='header'>
                  <h1>Chào mừng đến với YouAreHeard!</h1>
                </div>
                <div class='content'>
                  <p>Xin chào Bác sĩ,</p>
                  <p>Tài khoản của bác sĩ đã được quản trị viên tạo thành công. Dưới đây là thông tin đăng nhập của bác sĩ:</p>
                  <div class='info-box'>
                    <p><strong>Email:</strong> {toEmail}</p>
                    <p><strong>Mật khẩu:</strong> {password}</p>
                  </div>
                  <p>Bác sĩ có thể đăng nhập vào hệ thống bằng cách nhấn nút dưới đây:</p>
                  <a href='{loginUrl}' class='login-button'>Đăng nhập ngay</a>
                  <p>Nếu bác sĩ gặp khó khăn khi truy cập tài khoản, vui lòng liên hệ với đội ngũ hỗ trợ của chúng tôi.</p>
                  <p>Trân trọng cảm ơn bác sĩ đã tham gia vào hệ thống YouAreHeard.</p>
                </div>
                <div class='footer'>
                  &copy; 2025 YouAreHeard. Mọi quyền được bảo lưu.
                </div>
              </div>
            </body>
            </html>";

            using var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = htmlBody,
                IsBodyHtml = true
            };

            await smtp.SendMailAsync(message);
        }

        public class EmailSettings
        {
            public string From { get; set; }
            public string DisplayName { get; set; }
            public string SmtpHost { get; set; }
            public int SmtpPort { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public bool EnableSSL { get; set; }
        }
    }
}
