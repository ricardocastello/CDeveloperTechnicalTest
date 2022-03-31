using System;
using System.IO;

namespace technicaltests01
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wellcome - Cloud Commerce Group");
            Console.WriteLine("C# Developer Technical Test");

            var fileInfo = new FileInfo(args[0]);
            var dto = new ArquivoService();
            var arquivo = dto.TransformarCSV(fileInfo);

            var transformadorFactory = new TransformadorFactory();
            var transformador = transformadorFactory.Obter(args[1].ToUpper());
            
            var fileConverter = new FileConverter();
            var arquivoSaida = fileConverter.Converter(arquivo, transformador);

            File.WriteAllText(Path.ChangeExtension(fileInfo.FullName, args[1].ToLower()), arquivoSaida);
            Console.WriteLine(arquivoSaida);
        }
    }
}