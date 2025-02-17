using UnityEngine;

public class Destroyer : MonoBehaviour {



    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.TryGetComponent<BaseItem>(out var item)) {
            Destroy(item.gameObject);
        }
    }
}
