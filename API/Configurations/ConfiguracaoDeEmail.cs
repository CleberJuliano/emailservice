using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Configurations {
    public class ConfiguracaoDeEmail {
        public ConfiguracaoDeEmail(IConfiguration configuration) {

            Host = configuration["ConfiguracaoDeEmail:Host"];
            Port = Convert.ToInt32(configuration["ConfiguracaoDeEmail:Port"]);
            EnableSsl = Convert.ToBoolean(configuration["ConfiguracaoDeEmail:EnableSsl"]);
            Endereco = configuration["ConfiguracaoDeEmail:Endereco"];
            Senha = configuration["ConfiguracaoDeEmail:Senha"];
        }

        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public string Endereco { get; set; }
        public string Senha { get; set; }
    }
}
