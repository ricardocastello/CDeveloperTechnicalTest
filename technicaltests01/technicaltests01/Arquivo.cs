using System;
using System.Collections.Generic;
using System.Linq;

namespace technicaltests01
{
    public class Arquivo
    {
        private const string separator = "_";
        public Agrupamento[] Agrupamento { get; private set; }
        public List<String> Header { get; } = new List<String>();
        public List<Row> Data { get; } = new List<Row>();

        public void AdicionarCabecalho(IEnumerable<string> header)
        {
            Header.AddRange(header);

            Agrupamento = header.GroupBy(h => h.Prefix(separator))
                .Where(g => g.Count() > 1)
                .Select(g => new Agrupamento { Prefix = g.Key, Sufix = g.Select(i => i.Sufix(separator)).ToArray() })
                .ToArray();
        }

        public Agrupamento ObterAgrupamento(string coluna)
        {
            var prefix = coluna.Prefix(separator);
            return Agrupamento.FirstOrDefault(a => a.Prefix == prefix);
        }
    }
}