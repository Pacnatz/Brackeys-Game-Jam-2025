using UnityEngine;
using UnityEngine.InputSystem;

public class ShootScript : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileSpawn;
    public bool hasFired = false;

    public InputActionReference FireAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void GetInput()
    {
        hasFired = FireAction.action.WasPressedThisFrame();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        if (hasFired)
        {
            Debug.Log("Should fire");
            Instantiate(projectilePrefab, projectileSpawn);
        }
            
    }
}
