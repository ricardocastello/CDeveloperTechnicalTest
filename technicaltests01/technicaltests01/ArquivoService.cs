using System.IO;
using System.Linq;
using System.Text;

namespace technicaltests01
{
    public class ArquivoService
    {
        private const string separator = ";";

        public Arquivo TransformarCSV(FileInfo fileInfo)
        {
            var arquivo = new Arquivo();

            var linhasAquivo = File.ReadAllLines(fileInfo.FullName);

            var header = linhasAquivo.FirstOrDefault();
            arquivo.AdicionarCabecalho(header.Split(separator));

            foreach (var linhaArquivo in linhasAquivo.Skip(1))
            {
                var linha = new Row();
                linha.AdicionarColunas(linhaArquivo.Split(separator));
                arquivo.Data.Add(linha);
            }

            return arquivo;
        }
    }
}