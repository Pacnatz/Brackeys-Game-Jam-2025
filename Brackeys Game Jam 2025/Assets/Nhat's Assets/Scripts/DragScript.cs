using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class DragScript : MonoBehaviour {

    [SerializeField] private LayerMask itemsLayer;
    [SerializeField] private LayerMask selectedItemLayer;

    private GameObject selectedItem;
    private Vector3 offset;
    private Mouse mouse;
    private Vector2 worldPos;

    private void Start() {
        //itemsLayer = LayerMask.NameToLayer("Items");
        //selectedItemLayer = LayerMask.NameToLayer("SelectedItem");
    }

    private void Update() {
        mouse = Mouse.current;
        if (mouse != null) {
            worldPos = Camera.main.ScreenToWorldPoint(mouse.position.ReadValue());
            if (mouse.leftButton.wasPressedThisFrame) {
                CastObject();
            }
            if (mouse.leftButton.wasReleasedThisFrame) {
                RemoveObject();
            }

            // If we have a selected item
            if (selectedItem) {
                selectedItem.transform.position = Camera.main.ScreenToWorldPoint(mouse.position.ReadValue()) + offset;
            }
        }
    }


    private void CastObject() {
        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero, 100, itemsLayer);
        if (hit) {
            selectedItem = hit.collider.gameObject;
            selectedItem.layer = LayerMask.NameToLayer("SelectedItem");
            offset = selectedItem.transform.position - Camera.main.ScreenToWorldPoint(mouse.position.ReadValue());
        }
    }

    private void RemoveObject() {
        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero, 100, itemsLayer);
        if (hit) {
            // Call base item script's merge function
            Debug.Log(hit.collider.gameObject.name);
        }

        if (selectedItem) {
            selectedItem.layer = LayerMask.NameToLayer("Items");
            selectedItem = null;
        }


    }

}
