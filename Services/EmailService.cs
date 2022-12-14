using MimeKit;
using System.Net.Mail;
using System.Net;
using UsuariosAPI.Models;
using System.Text.Encodings.Web;
using System.Web;

namespace UsuariosAPI.Services
{
    public class EmailService
    {
        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void EnviarEmail(string[] destinatarios, string assunto, int id, string code)
        {
            var urlCode = HttpUtility.UrlEncode(code);
            Mensagem mensagem = new Mensagem(destinatarios, assunto, id, urlCode);
            var mensagemDeEmail = CriaCorpoDoEmail(mensagem, _configuration.GetValue<string>("EmailSettings:From"));
            Enviar(mensagemDeEmail);
        }

        private void Enviar(MimeMessage mensagemDeEmail)
        {
            var x = _configuration.GetValue<int>("EmailSettings:Port");
            var client = new SmtpClient("smtp.mailtrap.io", x)
            {
                Credentials = new NetworkCredential("c1162a70437d32", "b4c13d9184f55b"),
                EnableSsl = true
            };
            client.Send("from@example.com", "to@example.com", mensagemDeEmail.Subject, mensagemDeEmail.Body.ToString());
            Console.WriteLine("Sent");
        }

        private MimeMessage CriaCorpoDoEmail(Mensagem mensagem, string remetente)
        {
            var mensagemDeEmail = new MimeMessage();
            mensagemDeEmail.From.Add(new MailboxAddress(_configuration.GetValue<string>("EmailSettings:From"), remetente));
            mensagemDeEmail.To.AddRange(mensagem.Destinatario);
            mensagemDeEmail.Subject = mensagem.Assunto;
            mensagemDeEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = mensagem.Conteudo };
            return mensagemDeEmail;
        }
    }
}