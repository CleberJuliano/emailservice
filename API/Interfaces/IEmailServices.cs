using API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces {
    public interface IEmailServices {
        Task Enviar(EmailDto emailDto);
    }
}
