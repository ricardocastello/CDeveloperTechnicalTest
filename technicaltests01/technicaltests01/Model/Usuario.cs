using System;
using System.Runtime.Serialization;

namespace technicaltests01.Model
{
    public class Usuario : ISerializable
    {
        public string name { get; set; }
        public string address_line1 { get; set; }
        public string address_line2 { get; set; }


        public Usuario() { }

        #region Serialização

        /// <summary>
        ///  A função desserializar (remove dados do objeto do arquivo)
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ctxt"></param>
        public Usuario(SerializationInfo info, StreamingContext ctxt)
        {
            //Pegue os valores de informações e atribua-os às propriedades
            name = (string)info.GetValue("name", typeof(string));
            address_line1 = (string)info.GetValue("address_line1", typeof(string));
            address_line2 = (string)info.GetValue("address_line2", typeof(string));
            
        }

        /// <summary>
        /// Função de serialização (armazena dados do objeto no arquivo)
        /// SerializationInfo contém os pares de valores-chave
        /// StreamingContext pode conter informações adicionais, mas não estamos usando aqui
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            try
            {
                info.AddValue("name", name);
                info.AddValue("address_line1", address_line1);
                info.AddValue("address_line2", address_line2); 
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
