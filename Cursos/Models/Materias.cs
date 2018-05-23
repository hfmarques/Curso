using System.Xml.Serialization;

namespace Cursos.Models
{
    public class Materias
    {
        [XmlElement("codigo")]
        public int Codigo { get; set; }

        [XmlElement("nome")]
        public string Nome { get; set; }
    }
}