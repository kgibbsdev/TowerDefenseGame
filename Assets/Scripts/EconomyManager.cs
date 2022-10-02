using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    private int Gold = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CanAfford(int val)
    {
        return val <= Gold;
    }

    public void Spend(int val)
    {
        if(CanAfford(val))
        {
            Gold -= val;
        }
    }

    public void Deposit(int val)
    {
        Gold += val;
    }
}
