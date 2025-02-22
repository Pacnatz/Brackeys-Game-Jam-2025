using UnityEngine;

public class Rocket : MonoBehaviour {


    public float moveSpeed = 15f;

    [SerializeField] private GameObject explosionParticlesPrefab;
    
    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(-moveSpeed, 0);
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Wall") {
            Instantiate(explosionParticlesPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
