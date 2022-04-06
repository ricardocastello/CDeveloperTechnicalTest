using System;
using System.Collections.Generic;

namespace technicaltests01
{
    public class Row
    {
        public List<object> Columns { get; } = new List<object>();

        public void AddColumns(string[] valores)
        {
            Columns.AddRange(valores);
        }
    }
}