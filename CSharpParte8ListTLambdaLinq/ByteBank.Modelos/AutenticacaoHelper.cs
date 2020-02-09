using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.Modelos
{
    // private   - apenas acessado dentro da classe
    // protected - apenas acessado dentro da classe e classes derivadas
    // internal* - apenas acessado dentro do projeto
    // public    - acesso total permitido
    // * - DEFAULT
    class AutenticacaoHelper
    {
        public bool CompararSenhas(string senhaVerdadeira, string senhaTentativa)
        {
            return senhaVerdadeira == senhaTentativa;
        }
    }
}
