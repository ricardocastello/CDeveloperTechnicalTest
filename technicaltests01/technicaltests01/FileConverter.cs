namespace technicaltests01
{
    public class FileConverter
    {
        public string Convert(File file, ITransformer transform)
        {
           return transform.Convert(file);
        }
    }
}