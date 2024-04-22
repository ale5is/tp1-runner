using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_PowerUP : MonoBehaviour
{
    public static float powerVelocity;
    private Rigidbody rb;
    public static GameObject PowerUp;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PowerUp = this.gameObject;
    }

    void Update()
    {
        rb.AddForce(new Vector3(-powerVelocity, 0, 0), ForceMode.Force);
        OutOfBounds();
    }

    public void OutOfBounds()
    {
        if (this.transform.position.x <= -15)
        {
            Destroy(this.gameObject);
        }
    }
}
