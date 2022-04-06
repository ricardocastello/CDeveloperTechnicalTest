using System.IO;
using System.Linq;
using System.Text;

namespace technicaltests01
{
    public class ArquivoService
    {
        private const string separator = ";";

        public File TransformCSV(FileInfo fileInfo)
        {
            var file = new File();

            var linhasAquivo = System.IO.File.ReadAllLines(fileInfo.FullName);

            var header = linhasAquivo.FirstOrDefault();
            file.InsertHeader(header.Split(separator));

            foreach (var lineFile in linhasAquivo.Skip(1))
            {
                var line = new Row();
                line.AddColumns(lineFile.Split(separator));
                file.Data.Add(line);
            }

            return file;
        }
    }
}