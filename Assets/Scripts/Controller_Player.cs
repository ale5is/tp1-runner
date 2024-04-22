using UnityEngine;

public class Controller_Player : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce = 10;
    private float initialSize;
    private int i = 0;
    private bool floored;
    private int jumps= 0;
    private bool invencible;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialSize = rb.transform.localScale.y;
        invencible = false;
    }

    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        Jump();
        Duck();
    }

    private void Jump()
    {
        if (floored)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                jumps++;
            }
        }
        //cree un contador para los saltos y cuando detecte la colison del suelo se reinicia
        if (jumps == 1&&!floored)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                jumps++;
            }
        }
    }

    private void Duck()
    {
        if (floored)
        {
            if (Input.GetKey(KeyCode.S))
            {
                if (i == 0)
                {
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, rb.transform.localScale.y / 2, rb.transform.localScale.z);
                    i++;
                }
            }
            else
            {
                if (rb.transform.localScale.y != initialSize)
                {
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, initialSize, rb.transform.localScale.z);
                    i = 0;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                rb.AddForce(new Vector3(0, -jumpForce, 0), ForceMode.Impulse);
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {  
            if (invencible)
            {
                Destroy(Controller_Enemy.Enemy);
                invencible = false;
            }
            else 
            {
                Destroy(this.gameObject);
                Controller_Hud.gameOver = true; 
            }
            
        }

        if (collision.gameObject.CompareTag("PowerUP"))
        {
            Destroy(Controller_PowerUP.PowerUp);
            invencible = true;
            
         }

        if (collision.gameObject.CompareTag("Floor"))
        {
            floored = true;
            jumps = 0;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            floored = false;
            
        }
    }
}
