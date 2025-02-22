using UnityEngine;

public class BaseItem : MonoBehaviour {

    [HideInInspector] public BaseItem MergeItem;
    [HideInInspector] public string ItemColor;

    [SerializeField] protected GameObject highlightCircle;
    [SerializeField] protected float damage;

    protected Boss bossScript;
    protected SplashScript splashScript;
    
    [SerializeField] protected float successChance;

    protected bool isSelected = false;
    protected bool onConveyor;
    private float conveyorPosX = -4f;


    private void Start() {
        highlightCircle.SetActive(false);
        bossScript = FindAnyObjectByType<Boss>();
        splashScript = FindAnyObjectByType<SplashScript>();
    }

    private void Update() {
        // Base item can only go as high as conveyorPosY
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8, conveyorPosX), transform.position.y, transform.position.z);
    }


    public virtual void Merge() {
        // What each individual color will override
    }

    protected void DestroyBothItems() {
        Destroy(MergeItem.gameObject);
        Destroy(gameObject);
    }

    public bool getOnConveyor() => onConveyor;
    public void setOnConveyor(bool val) { onConveyor = val; }
    public bool getIsSelected() => isSelected;
    public void setIsSelected(bool val) { isSelected = val; }
}
