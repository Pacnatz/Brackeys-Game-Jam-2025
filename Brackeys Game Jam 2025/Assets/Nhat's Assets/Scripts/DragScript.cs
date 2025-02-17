using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class DragScript : MonoBehaviour {

    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private LayerMask itemsLayer;
    [SerializeField] private LayerMask selectedItemLayer;

    private PlayerInput playerInput;
    private Mouse mouse;

    private float playerSpeed = 5f;
    private float playerAcceleration = 10f;

    private GameObject selectedItem;
    private Vector3 offset;
    private Vector2 worldPos;

    private void Start() {
        playerInput = new PlayerInput();
        playerInput.Player.Enable();
    }

    private void Update() {

        // Mouse logic
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

        // 1D Keyboard logic
        float moveDirX = playerInput.Player.PlayerMove.ReadValue<float>();
        if (moveDirX != 0) {

            // Decelerate twice as fast if moving in opposite directions
            if (playerRb.linearVelocityX > moveDirX) {
                playerRb.linearVelocityX = Mathf.MoveTowards(playerRb.linearVelocityX, moveDirX * playerSpeed, playerAcceleration * 2 * Time.deltaTime);
            }
            else if (playerRb.linearVelocityX < moveDirX) {
                playerRb.linearVelocityX = Mathf.MoveTowards(playerRb.linearVelocityX, moveDirX * playerSpeed, playerAcceleration * 2 * Time.deltaTime);
            }
            else {
                playerRb.linearVelocityX = Mathf.MoveTowards(playerRb.linearVelocityX, moveDirX * playerSpeed, playerAcceleration * Time.deltaTime);
            }
        }
        else {
            playerRb.linearVelocityX = Mathf.MoveTowards(playerRb.linearVelocityX, 0, playerAcceleration * 2 * Time.deltaTime);
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
