using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeable : MonoBehaviour
{
    private Color BaseColor;
    private bool isCarried = false;
    public int Transparency;
    public bool IsCarried
    {
        get {
            return isCarried;
        }
        set
        {
            if (value)
            {
                SetTransparent();
            } else
            {
                SetSolid();
            }
            isCarried = value;
        }
    }
    public List<SpriteRenderer> BaseMaterial;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            isCarried = !isCarried;
        } else if (Input.GetKeyUp(KeyCode.P))
        {
            //isCarried = false;
        }
    }

    private void SetTransparent()
    {
        BaseMaterial.ForEach((m) =>
        {
            BaseColor = m.color;
            BaseColor.a = 0.65f;
            m.material.color = BaseColor;
        });
    }

    private void SetSolid()
    {
        BaseMaterial.ForEach((m) =>
        {
            BaseColor = m.color;
            BaseColor.a = 1.0f;
            m.material.color = BaseColor;
        });
    }
}
