using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.Rendering;

public class Boss : MonoBehaviour
{
    Rigidbody2D rb2;
    public float healthValue = 50f;
    float currentHealthVal;
    float timeBeforeAtk = 6f;

    public GameObject bossProjectile;

    public HealthBarScript hpBar;
    ProjectileScript projectile;

    private void Awake()
    {
        rb2 = GetComponentInParent<Rigidbody2D>();
        if (rb2 == null )
        {
            Debug.LogWarning("No rigidbody2d on " + gameObject.name + ".");
        }
        if ( hpBar == null )
        {
            Debug.LogWarning("Missing HealthBarScript on " + gameObject.name + ".");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hpBar.SetMaxHealth(healthValue);
    }

    // Update is called once per frame
    void Update()
    { 
        timeBeforeAtk -= Time.deltaTime;
        if (timeBeforeAtk <= 0)
        {
            Attack();
        }
    }

    void Attack()
    {
        timeBeforeAtk = 6f;
        Instantiate(bossProjectile);
        Debug.Log("Boss attacking.");
    }

    public void TakeDamage(float damage)
    {
        currentHealthVal -= damage;
        hpBar.SetHealth(currentHealthVal);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TakeDamage(projectile.damage);
    }

}
