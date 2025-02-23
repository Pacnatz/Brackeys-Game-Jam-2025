using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour {


    public float maxHealth;

    [SerializeField] private Image hpBar;
    private float health;

    private void Start() {
        health = maxHealth;
    }

    private void Update() {

        hpBar.fillAmount = Mathf.Lerp(hpBar.fillAmount, health / maxHealth, 10 * Time.deltaTime);

        if (health <= 0) {
            SceneManager.LoadScene("GameOver");
        }
    }
    public void TakeDamage(float val) {
        health -= val;
    }


}
