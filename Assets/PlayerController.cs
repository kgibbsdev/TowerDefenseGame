using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontal = 0f;
    float vertical = 0f;
    public float MovementSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal") * MovementSpeed * Time.deltaTime;
        vertical = Input.GetAxis("Vertical") * MovementSpeed * Time.deltaTime;
        
        Vector3 movementVector = new Vector3(horizontal, vertical, 0);
        transform.Translate(movementVector);        
    }
}
