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
            var file = dto.TransformCSV(fileInfo);

            var transformFactory = new TransformFactory();
            var transformer = transformFactory.getType(args[1].ToUpper());
            
            var fileConverter = new FileConverter();
            var FileExit = fileConverter.Convert(file, transformer);

            System.IO.File.WriteAllText(Path.ChangeExtension(fileInfo.FullName, args[1].ToLower()), FileExit);
            Console.WriteLine(FileExit);
        }
    }
}