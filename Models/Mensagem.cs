using MimeKit;

namespace UsuariosAPI.Models
{
    public class Mensagem
    {
        public List<MailboxAddress> Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }

        public Mensagem(IEnumerable<string> destinatarios, string assunto, int id, string codigo)
        {
            Destinatario = new List<MailboxAddress>();
            Destinatario.AddRange(destinatarios.Select(destinatario => new MailboxAddress("", destinatario)));
            Assunto = assunto;
            Conteudo = $"http://localhost:6000/ativa?UsuarioId={id}&CodigoDeAtivacao={codigo}";
        }
    }
}
