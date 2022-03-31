using System;
using System.Runtime.Serialization;

namespace technicaltests01.Model
{
    public class Usuario : ISerializable
    {
        public string name { get; set; }
        public string address_line1 { get; set; }
        public string address_line2 { get; set; }


    }
}
