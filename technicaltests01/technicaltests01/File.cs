using System;
using System.Collections.Generic;
using System.Linq;

namespace technicaltests01
{
    public class File
    {
        private const string separator = "_";
        public Group[] XMLGroup { get; private set; }
        public List<String> Header { get; } = new List<String>();
        public List<Row> Data { get; } = new List<Row>();

        public void InsertHeader(IEnumerable<string> header)
        {
            Header.AddRange(header);

            XMLGroup = header.GroupBy(h => h.Prefix(separator))
                .Where(g => g.Count() > 1)
                .Select(g => new Group { Prefix = g.Key, Sufix = g.Select(i => i.Sufix(separator)).ToArray() })
                .ToArray();
        }

        public Group GetGroup(string coluna)
        {
            var prefix = coluna.Prefix(separator);
            return XMLGroup.FirstOrDefault(a => a.Prefix == prefix);
        }
    }
}