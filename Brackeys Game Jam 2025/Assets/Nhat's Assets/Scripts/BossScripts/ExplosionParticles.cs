using UnityEngine;

public class ExplosionParticles : MonoBehaviour {
    private void Awake() {
        transform.position = new Vector3(transform.position.x - .8f, transform.position.y, transform.position.z);
        transform.Rotate(new Vector3(0, 90, 0));
        Destroy(gameObject, 1f);
    }
}
