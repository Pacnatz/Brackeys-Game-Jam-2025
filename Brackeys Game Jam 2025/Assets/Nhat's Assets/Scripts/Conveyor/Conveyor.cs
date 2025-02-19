using UnityEngine;
using System.Collections.Generic;

public class Conveyor : MonoBehaviour {

    public float conveyorSpeed = 2f;

    private List<BaseItem> itemsOnConveyor = new List<BaseItem>();


    private void Update() {
        
        foreach (BaseItem item in itemsOnConveyor) {
            // If item is on conveyor
            if (item.getOnConveyor()) {
                item.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(conveyorSpeed, 0);
            }
        }

    }


    public void OnTriggerStay2D(Collider2D collision) {

        if (collision.gameObject.TryGetComponent<BaseItem>(out var item)) {

            // If item is not on conveyor
            if (!item.getOnConveyor()) {
                item.setOnConveyor(true);
                collision.transform.position = new Vector3(collision.transform.position.x, -1.5f, collision.transform.position.z);
                itemsOnConveyor.Add(item);
            }

        }
    }

    public void OnTriggerExit2D(Collider2D collision) {
        
        if (collision.gameObject.TryGetComponent<BaseItem>(out var item)) {
            item.setOnConveyor(false);
            item.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            itemsOnConveyor.Remove(item);
        }
    }
}
