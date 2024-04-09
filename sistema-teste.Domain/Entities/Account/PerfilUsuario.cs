using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_teste.Domain.Entities.Account
{
    public class PerfilUsuario
    {
        public User Usuario { get; set; }
        public Perfil Perfil { get; set; }
    }
}
