using UnityEngine;

public class BaseItem : MonoBehaviour {

    [HideInInspector] public BaseItem MergeItem;
    [HideInInspector] public string ItemColor;

    protected float successChance;
    protected float failChance;

    protected bool isSelected = false;
    protected bool onConveyor;
    private float conveyorPosX = -4f;


    private void Update() {
        // Base item can only go as high as conveyorPosY
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8, conveyorPosX), transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // If it's selected assign the mergingItem;
        if (isSelected) {
            if (collision.TryGetComponent<BaseItem>(out var mergeItem)) {
                if (mergeItem.onConveyor == false) {
                    MergeItem = mergeItem;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        // Assign MergeItem to null
        if (isSelected) {
            if (collision.TryGetComponent<BaseItem>(out var mergeItem)) {
                if (mergeItem.onConveyor == false) {
                    MergeItem = null;
                }
            }
        }
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
