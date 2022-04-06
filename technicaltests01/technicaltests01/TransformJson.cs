using System;

namespace technicaltests01
{
    public class TransformJson : ITransformer
    {
        public string Convert(File file)
        {
            var jsonResult = "";
            foreach (var linha in file.Data)
            {
                var json = "";
                int i = 0;
                while (i < file.Header.Count)
                {
                    var column = file.Header[i];
                    var groupText = file.GetGroup(column);
                    if (groupText == null)
                    {
                        var valor = linha.Columns[i];
                        json += $@",""{column}"" : ""{valor}""";
                        i++;
                    }
                    else
                    {
                        var json1 = "";
                        //json1 += $@",""{agrupamento.Prefix}"" : ";
                        foreach (var sufix in groupText.Sufix)
                        {
                            var valor = linha.Columns[i];
                            json1 += $@",""{sufix}"" : ""{valor}""";
                            i++;
                        }
                        json += $@",""{groupText.Prefix}"" : " + "{" + json1.Substring(1) + "}";
                    }
                }
                jsonResult += ",{" + json.Substring(1) + "}";
            }
            return "[" + jsonResult.Substring(1) + "]";
        }
    }
}