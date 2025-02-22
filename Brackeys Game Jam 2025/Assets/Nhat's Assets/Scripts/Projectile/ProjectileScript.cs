using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    public float damage = 0.5f;
    public float speed = 10.0f;
    Rigidbody2D rb;
    Boss boss;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Add a rigidbody you shloingus.");
            return;
        }
               
    }

    private void Start()
    {
        rb.linearVelocity = gameObject.transform.right * speed;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        rb.AddForce(gameObject.transform.right * speed * Time.deltaTime);
        
    }

}
