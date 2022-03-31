using System;

namespace technicaltests01
{
    public class TransformadorJson : ITransformador
    {
        public string Converter(Arquivo arquivo)
        {
            var jsonResult = "";
            foreach (var linha in arquivo.Data)
            {
                var json = "";
                int i = 0;
                while (i < arquivo.Header.Count)
                {
                    var coluna = arquivo.Header[i];
                    var agrupamento = arquivo.ObterAgrupamento(coluna);
                    if (agrupamento == null)
                    {
                        var valor = linha.Columns[i];
                        json += $@",""{coluna}"" : ""{valor}""";
                        i++;
                    }
                    else
                    {
                        var json1 = "";
                        //json1 += $@",""{agrupamento.Prefix}"" : ";
                        foreach (var sufixo in agrupamento.Sufix)
                        {
                            var valor = linha.Columns[i];
                            json1 += $@",""{sufixo}"" : ""{valor}""";
                            i++;
                        }
                        json += $@",""{agrupamento.Prefix}"" : " + "{" + json1.Substring(1) + "}";
                    }
                }
                jsonResult += ",{" + json.Substring(1) + "}";
            }
            return "[" + jsonResult.Substring(1) + "]";
        }
    }
}