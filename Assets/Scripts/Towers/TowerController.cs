using UnityEngine;

// Todo: possibly implement a tower fixed update
// Todo: possibly store the towers initial spawn, and reset the tower each round

/// <summary>
/// Base class for towers. Implements buying/dragging functionality.
/// <para>To create a new tower, please inherit from this and implement TowerStart and TowerUpdate.</para>
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Placeable))]
public class TowerController : MonoBehaviour
{
    private Placeable TowerPlaceable;
    protected Rigidbody2D Body;
    public GameObject Target;
    public Camera TowerCamera;

    protected virtual void TowerStart() { }
    protected virtual void TowerUpdate() { }

    protected void Awake()
    {
        Body = this.GetComponent<Rigidbody2D>();
        TowerPlaceable = this.GetComponent<Placeable>();
    }

    protected void Start()
    {
        TowerStart();
    }

    protected void Update()
    {
        if (TowerPlaceable.IsCarried)
        {
            Vector3 temp = TowerCamera.ScreenToWorldPoint(Input.mousePosition);
            temp.z = 0;
            this.transform.position = temp;
        }
        else
        {
            TowerUpdate();
        }
    }
}