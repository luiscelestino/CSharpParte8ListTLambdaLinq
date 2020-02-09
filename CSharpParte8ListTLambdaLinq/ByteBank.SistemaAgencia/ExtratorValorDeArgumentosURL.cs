using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ExtratorValorDeArgumentosURL
    {
        private readonly string _argumentos;
        public string URL { get; }

        public ExtratorValorDeArgumentosURL(string url)
        {
            if (String.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("O argumento " + nameof(url) + " não pode ser nulo ou vazio.", nameof(url));
            }

            URL = url;

            _argumentos = url.Substring(url.IndexOf('?') + 1);
        }

        // moedaOrigem=real&moedaDestino=dolar
        public string GetValor(string nomeParametro)
        {
            string valorParametro;

            // Normalizando para tudo em caixa alta
            nomeParametro = nomeParametro.ToUpper();
            string argumentosEmCaixaAlta = _argumentos.ToUpper();

            // Verifica se o nome do parâmetro existe
            if (!argumentosEmCaixaAlta.Contains(nomeParametro))
            {
                throw new ArgumentException("O valor de " + nameof(nomeParametro) + "inexiste na url.", 
                    nameof(nomeParametro));
            }

            // Retira o que tem antes do valor do parâmetro
            int indiceParametro = argumentosEmCaixaAlta.IndexOf(nomeParametro + "=");
            int indiceValor = indiceParametro + nomeParametro.Length + 1;
            valorParametro = _argumentos.Substring(indiceValor);

            // Retira o que tem depois do valor do parâmetro
            int indiceEComercial = valorParametro.IndexOf('&');

            if (indiceEComercial >= 0)
            {
                valorParametro = valorParametro.Remove(indiceEComercial);
            }

            return valorParametro;
        }
    }
}
