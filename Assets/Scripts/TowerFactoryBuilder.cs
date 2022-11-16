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
                CannonController cannon = new CannonController(body, TowerInfo);
                cannon.FireFrequency = TowerInfo.BaseSpeed;
                return cannon;
            case TowerType.MINI_CANNON:
                CannonController minicannon = new CannonController(body, TowerInfo);
                minicannon.FireFrequency = 1.5f;
                return minicannon;
            default: return null;
        }
    }
}
