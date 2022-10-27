using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
[XmlRoot("WaveCollection")]
public class WaveCollection
{
    //[XmlArray]
    //[XmlArrayItem("Wave", typeof(Wave))]
    [XmlElement("Wave")]
    public List<Wave> Waves { get; set; }
}


