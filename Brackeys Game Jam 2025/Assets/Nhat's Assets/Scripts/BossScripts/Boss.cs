using UnityEngine;

public class Boss : MonoBehaviour
{
    Rigidbody2D rb2;

    private void Awake()
    {
        rb2 = GetComponentInParent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
