namespace technicaltests01
{
    public class TransformadorXml : ITransformador
    {
        public string Converter(Arquivo arquivo)
        {
            var xmlResult = "";

            foreach (var linha in arquivo.Data)
            {
                var xml = "";
                int i = 0;
                while (i < arquivo.Header.Count)
                {
                    var coluna = arquivo.Header[i];
                    var agrupamento = arquivo.ObterAgrupamento(coluna);
                    if (agrupamento == null)
                    {
                        var valor = linha.Columns[i];
                        xml += $"<{coluna}>{valor}</{coluna}>";
                        i++;
                    }
                    else
                    {
                        var xml1 = "";
                        foreach (var sufixo in agrupamento.Sufix)
                        {
                            var valor = linha.Columns[i];
                            xml1 += $@"<{sufixo}>{valor}</{sufixo}>";
                            i++;
                        }
                        xml += $@"<{agrupamento.Prefix}>{xml1}</{agrupamento.Prefix}>";
                    }
                }

                xmlResult += "<Entity>" + xml + "</Entity>";

            }
            return "<Root>" + xmlResult + "</Root>";
        }
    }
}