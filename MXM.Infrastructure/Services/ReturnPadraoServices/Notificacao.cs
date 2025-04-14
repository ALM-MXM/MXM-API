using MXM.Infrastructure.Services.ReturnPadraoServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXM.Infrastructure.Services.ReturnPadraoServices
{
    public class Notificacao
    {
        public string Mensagem { get; set; } = string.Empty!;
        public EnumTipoNotificacao Tipo { get; set; }
        public Notificacao(EnumTipoNotificacao tipo, string mensagem)
        {
            Tipo = tipo;
            Mensagem = mensagem;
        }

        public Notificacao(Exception exception)
        {
            Tipo = EnumTipoNotificacao.Erro;
            Mensagem = exception.Message;
        }

        public Notificacao() { }

        public Notificacao(Messages message)
        {
            switch (message.TypeMessage)
            {
                case "Erro":
                    Tipo = EnumTipoNotificacao.Erro;
                    break;
                case "Aviso":
                    Tipo = EnumTipoNotificacao.Aviso;
                    break;
                case "Mensagem":
                    Tipo = EnumTipoNotificacao.Informacao;
                    break;
                default:
                    Tipo = EnumTipoNotificacao.Informacao;
                    break;
            }

            Mensagem = message.Message;
        }
    }

    public class Messages
    {
        public string Message { get; set; } = string.Empty!;
        public string Detail { get; set; } = string.Empty!;
        public int Type { get; set; }
        public string TypeMessage { get; set; } = string.Empty!;
        public int ErrorLevel { get; set; }
        public string Code { get; set; } = string.Empty!;
    }
}

    public static class MensagemExtensions
    {
        public static void AdicionarErro(this List<Notificacao> lista, string mensagem)
        {
            lista.Add(new Notificacao(EnumTipoNotificacao.Erro, mensagem));
        }
        public static void AdicionarExcecao(this List<Notificacao> lista, Exception exception)
        {
            lista.Add(new Notificacao(exception));
        }
        public static void AdicionarAviso(this List<Notificacao> lista, string mensagem)
        {
            lista.Add(new Notificacao(EnumTipoNotificacao.Aviso, mensagem));
        }
        public static void AdicionarInformacao(this List<Notificacao> lista, string mensagem)
        {
            lista.Add(new Notificacao(EnumTipoNotificacao.Informacao, mensagem));
        }

        public static bool TemErros(this List<Notificacao> lista)
        {
            return lista.Any(n => n.Tipo == EnumTipoNotificacao.Erro);
        }
    }
