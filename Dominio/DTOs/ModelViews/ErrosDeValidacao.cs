using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace MinhaApi.Dominio.DTOs.ModelViews
{
    public class ErrosDeValidacao
    {
        public List<string> Mensagens { get; set; } = new List<string>();
    }
}
