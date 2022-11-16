using System.Collections.Generic;
using System.Xml.Serialization;

public class Wave
{
    //[XmlArray]
    //[XmlArrayItem("EnemyPack", typeof(EnemyPack))]
    [XmlElement("EnemyPack")]
    public List<EnemyPack> EnemyPacks { get; set; }
}