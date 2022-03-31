namespace technicaltests01
{
    public class FileConverter
    {
        public string Converter(Arquivo arquivo, ITransformador transformador)
        {
           return transformador.Converter(arquivo);
        }
    }
}