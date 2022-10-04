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

    public static Tower BuildTower(TowerType type, Rigidbody2D body)
    {
        switch (type)
        {
            case TowerType.CANNON:
                CannonController cannon = new CannonController(body);
                cannon.FireFrequency = 3.0f;
                return cannon;
            case TowerType.MINI_CANNON:
                CannonController minicannon = new CannonController(body);
                minicannon.FireFrequency = 1.5f;
                return minicannon;
            default: return null;
        }
    }

}
