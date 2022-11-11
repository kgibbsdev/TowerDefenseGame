using System.Collections.Generic;
using System.Xml.Serialization;
[XmlRoot("WaveCollection")]
public class WaveCollection
{
    //[XmlArray]
    //[XmlArrayItem("Wave", typeof(Wave))]
    [XmlElement("Wave")]
    public List<Wave> Waves { get; set; }
}


