using UnityEngine;

public class Controller_Enemy : MonoBehaviour
{
    public static float enemyVelocity;
    private Rigidbody rb;
    public static GameObject Enemy;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        Enemy=this.gameObject;
    }

    void Update()
    {
        rb.AddForce(new Vector3(-enemyVelocity, 0, 0), ForceMode.Force);
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
