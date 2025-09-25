using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    int health = 3;
    float oxygen= 100f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Smoke")) 
        {
            oxygen -= 5 * Time.deltaTime;
        }
        
            
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fire")) 
        {
            health -= 1;
            rb.transform.position = new Vector3(0,0,0);
        }
    }
}
