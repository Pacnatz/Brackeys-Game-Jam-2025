using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using System.Collections;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{

    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Image hpBar;
    [SerializeField] private float maxHealth;
    [SerializeField] private GameObject gameOverScreen;

    private float health;

    private int state = 0;
    private bool canTransitionState = false;

    private float minIdleDelay = 1.5f;
    private float maxIdleDelay = 3f;

    private Rigidbody2D rb;
    private Animator anim;
    private Material mat;

    private bool isFlashing = false;
    private float flashAmount = 0;

    private void Awake()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
        mat = gameObject.GetComponentInChildren<SpriteRenderer>().material;
        if (rb == null )
        {
            Debug.LogWarning("No rigidbody2d on " + gameObject.name + ".");
        }
        if ( hpBar == null )
        {
            Debug.LogWarning("Missing HealthBarObject on " + gameObject.name + ".");
        }
    }

    void Start()
    {
        health = maxHealth;
        StartCoroutine(BeginBoss(1f));
    }

    void Update()
    {
        hpBar.fillAmount = Mathf.Lerp(hpBar.fillAmount, health / maxHealth, 10 * Time.deltaTime);


        // State machine
        if (canTransitionState) {
            canTransitionState = false;
            switch (state) {
                case 0:
                    anim.Play("Idle");
                    StartCoroutine(DoIdlePhase());

                    break;
                case 1:
                    anim.Play("Attack");
                    StartCoroutine(DoAttack1Phase());
                    break;
            }
        }


        // Flash Logic
        if (isFlashing) {
            float flashRate = 2f;
            flashAmount = Mathf.Lerp(flashAmount, 0, flashRate * Time.deltaTime);
            mat.SetFloat("_FlashValue", flashAmount);
            if (flashAmount <= 0.05) {
                flashAmount = 0;
                mat.SetFloat("_FlashValue", 0);
            }
        }

        if (health <= 0) {
            // Death logic
            FindFirstObjectByType<AudioManager>().Play("GameOverSound");
            SceneManager.LoadScene("GameOver");
        }
    }



    private IEnumerator BeginBoss(float delay) {
        yield return new WaitForSeconds(delay);
        canTransitionState = true;
    }
    private IEnumerator DoIdlePhase() {
        yield return new WaitForSeconds(Random.Range(minIdleDelay, maxIdleDelay));
        state = 1;
        canTransitionState = true;
    }
    private IEnumerator DoAttack1Phase() {
        yield return new WaitForSeconds(.8f);

        int numRocketSpawned = 15;
        for (int i = 0; i < numRocketSpawned; i++) {
            StartCoroutine(SpawnRockets(i * .25f));
        }


        float attackAnimTime = 3f;
        yield return new WaitForSeconds(attackAnimTime);
        anim.Play("Idle");
        float minAttackTime = 4f;
        yield return new WaitForSeconds(minAttackTime);
        state = 0;
        canTransitionState = true;
    }

    private IEnumerator SpawnRockets(float delay) {
        yield return new WaitForSeconds(delay);
        Instantiate(rocketPrefab, new Vector3(12, Random.Range(-4.5f, 4.5f), -2), Quaternion.identity);
    }


    public void TakeDamage(float damage, Color color)
    {
        health -= damage;


        mat.SetColor("_FlashColor", color);
        isFlashing = true;
        flashAmount = 1;


    }

}

public enum BossState {
    Idle,
    Attack1
}
