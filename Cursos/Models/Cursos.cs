using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Cursos.Models
{
    [XmlType("Cursos")]
    public class Cursos
    {
        [XmlElement("materias")]
        public List<Materias> Materias { get; set; }        
    }
}