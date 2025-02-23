using UnityEngine;

public class Rocket : MonoBehaviour {

    public float rocketDamage = 2.5f;
    public float moveSpeed = 15f;
    
    [SerializeField] private GameObject explosionParticlesPrefab;
    
    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(-moveSpeed, 0);
        FindFirstObjectByType<AudioManager>().Play("RocketBlast");
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Wall") {
            Instantiate(explosionParticlesPrefab, transform.position, Quaternion.identity);
            FindFirstObjectByType<AudioManager>().Play("RocketImpact");
            Destroy(gameObject);
        }
        if (collision.name == "Player")
        {
            collision.TryGetComponent<Player>(out var player);
            Instantiate(explosionParticlesPrefab, transform.position, Quaternion.identity);
            FindFirstObjectByType<AudioManager>().Play("RocketImpact");
            player.TakeDamage(rocketDamage);
            Destroy(gameObject);


        }
    }
}
