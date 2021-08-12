using API.Configurations;
using API.Dtos;
using API.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace API.AppsServices {
    public class EmailServices : IEmailServices {
        private readonly IConfiguration configuration;

        public EmailServices(IConfiguration configuration) {
            this.configuration = configuration;
        }
        public async Task Enviar(EmailDto emailDto) {
            var configuracaoDeEmail = new ConfiguracaoDeEmail(this.configuration);
            var mensagemDeEmail = new MailMessage();

            var smtpClient = new SmtpClient {
                Host = configuracaoDeEmail.Host,
                Port = configuracaoDeEmail.Port,
                EnableSsl = configuracaoDeEmail.EnableSsl,
                Credentials = new NetworkCredential(configuracaoDeEmail.Endereco, configuracaoDeEmail.Senha),
                TargetName = $"STARTTLS/{configuracaoDeEmail.Host}",
            };

            mensagemDeEmail.From = new MailAddress("admin@dominio.com", emailDto.NomeDaAplicacao);
            mensagemDeEmail.To.Insert(0, new MailAddress(emailDto.EmailDeDestino));
            mensagemDeEmail.Subject = emailDto.Titulo;
            mensagemDeEmail.Body = emailDto.Conteudo;
            mensagemDeEmail.IsBodyHtml = true;

            await smtpClient.SendMailAsync(mensagemDeEmail);
        }
    }
}
