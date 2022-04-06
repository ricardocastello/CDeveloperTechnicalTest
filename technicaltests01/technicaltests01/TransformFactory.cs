using System;

namespace technicaltests01
{
    public class TransformFactory
    {
        public ITransformer getType(string formato)
        {
            switch (formato)
            {
                case "JSON":
                    return new TransformJson();
                case "XML":
                    return new TransformXml();
                default:
                    throw new NotImplementedException("Unknown Format");
            }
        }
    }
}