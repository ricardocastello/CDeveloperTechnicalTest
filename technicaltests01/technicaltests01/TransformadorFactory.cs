using System;

namespace technicaltests01
{
    public class TransformadorFactory
    {
        public ITransformador Obter(string formato)
        {
            switch (formato)
            {
                case "JSON":
                    return new TransformadorJson();
                case "XML":
                    return new TransformadorXml();
                default:
                    throw new NotImplementedException("Formato desconhecido");
            }
        }
    }
}