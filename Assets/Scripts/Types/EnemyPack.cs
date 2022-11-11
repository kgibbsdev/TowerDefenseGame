using System.Xml.Serialization;

public class EnemyPack
{
    [XmlElement]
    public int Type { get; set; }
    [XmlElement]
    public int EnemyCount { get; set; }


}
