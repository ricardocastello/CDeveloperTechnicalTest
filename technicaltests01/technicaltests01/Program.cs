using System;
using System.IO;

namespace technicaltests01
{
    /// <summary>
    /// CommandLine Nuget Package
    /// SQLite
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem Vindo.");

            var fileInfo = new FileInfo(args[0]);
            var dto = new ArquivoService();
            var arquivo = dto.TransformarCSV(fileInfo);

            var fileConverter = new FileConverter();
            var transformadorFactory = new TransformadorFactory();
            var transformador = transformadorFactory.Obter(args[1].ToUpper());

            var arquivoSaida = fileConverter.Converter(arquivo, transformador);
            File.WriteAllText(Path.ChangeExtension(fileInfo.FullName, args[1].ToLower()), arquivoSaida);
            Console.WriteLine(arquivoSaida);
        }
    }
}