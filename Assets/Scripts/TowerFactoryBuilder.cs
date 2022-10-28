using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerType
{
    CANNON,
    MINI_CANNON
}

public static class TowerFactoryBuilder
{
    public static Tower BuildTower(TowerScriptable TowerInfo, Rigidbody2D body)
    {
        switch (TowerInfo.Type)
        {
            case TowerType.CANNON:
                CannonController cannon = new CannonController(body);
                cannon.FireFrequency = TowerInfo.BaseSpeed;
                return cannon;
            case TowerType.MINI_CANNON:
                CannonController minicannon = new CannonController(body);
                minicannon.FireFrequency = 1.5f;
                return minicannon;
            default: return null;
        }
    }
}
