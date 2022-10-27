using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Wave
{
    //[XmlArray]
    //[XmlArrayItem("EnemyPack", typeof(EnemyPack))]
    [XmlElement("EnemyPack")]
    public List<EnemyPack> EnemyPacks { get; set; }
}