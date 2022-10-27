using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EnemyPack
{
  [XmlElement]
  public int Type { get; set; }
  [XmlElement]
  public int EnemyCount { get; set; }

	
}
