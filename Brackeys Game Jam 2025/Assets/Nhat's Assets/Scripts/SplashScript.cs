using UnityEngine;

public class SplashScript : MonoBehaviour {

    private bool splashOnScreen = false;
    private Material mat;
    private float alphaValue;
    private float fadeRate = .5f;

    private void Awake() {
        mat = GetComponent<SpriteRenderer>().material;
        mat.SetFloat("_AlphaValue", 0);
    }

    private void Update() {
        if (splashOnScreen) {
            alphaValue = Mathf.Lerp(alphaValue, 0, fadeRate * Time.deltaTime);
            mat.SetFloat("_AlphaValue", alphaValue);
            if (alphaValue <= 0) {
                splashOnScreen = false;
            }
        }
        else {
            mat.SetFloat("_AlphaValue", 0);
        }

    }

    public void StartSplash(Color color) {
        mat.SetColor("_SplashColor", color);
        splashOnScreen = true;
        alphaValue = 1;
    }


}
