using UnityEngine;

public class BaseItem : MonoBehaviour {

    [HideInInspector] public BaseItem MergeItem;
    [HideInInspector] public string ItemColor;

    [SerializeField] protected GameObject highlightCircle;

    protected float successChance;
    protected float failChance;

    protected bool isSelected = false;
    protected bool onConveyor;
    private float conveyorPosX = -4f;


    private void Start() {
        highlightCircle.SetActive(false);
    }

    private void Update() {
        // Base item can only go as high as conveyorPosY
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8, conveyorPosX), transform.position.y, transform.position.z);
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision) {
        // If the dragged item goes into trigger assign the this to the mergingItem

        collision.TryGetComponent<BaseItem>(out var selectedItem);
        if (selectedItem) {
            if (selectedItem.isSelected && selectedItem.MergeItem == null) {
                if (!onConveyor) { 
                    selectedItem.MergeItem = this;
                    highlightCircle.SetActive(true);
                }
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision) {
        // Assign MergeItem to null

        collision.TryGetComponent<BaseItem>(out var selectedItem);
        if (selectedItem) {
            if (selectedItem.isSelected && selectedItem.MergeItem == this) {
                if (!onConveyor) {
                    selectedItem.MergeItem = null;
                    highlightCircle.SetActive(false);
                }
            }
        }

    }
    */


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
