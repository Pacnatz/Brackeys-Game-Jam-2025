using UnityEngine;

public class BlueItem : BaseItem {

    public GameObject PurpleItemPrefab;
    public GameObject GreenItemPrefab;
    public GameObject NavyItemPrefab;


    private void Awake() {
        ItemColor = "Blue";
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // If the dragged item goes into trigger assign the this to the mergingItem

        collision.TryGetComponent<BaseItem>(out var selectedItem);
        if (selectedItem) {
            if (selectedItem.getIsSelected() && selectedItem.MergeItem == null) {
                if (!onConveyor) {
                    if (CheckMerge(selectedItem)) {
                        selectedItem.MergeItem = this;
                        highlightCircle.SetActive(true);
                    }
                }
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision) {
        // Assign MergeItem to null

        collision.TryGetComponent<BaseItem>(out var selectedItem);
        if (selectedItem) {
            if (selectedItem.getIsSelected() && selectedItem.MergeItem == this) {
                if (!onConveyor) {
                    selectedItem.MergeItem = null;
                    highlightCircle.SetActive(false);
                }
            }
        }

    }

    private bool CheckMerge(BaseItem selectedItem) {
        switch (selectedItem.ItemColor) {
            case "Blue":
                return true;
            case "Red":
                return true;
            case "Yellow":
                return true;
            case "Green":
                return true;
        }
        return false;
    }

    public override void Merge() {
        if (MergeItem.ItemColor == ItemColor) {
            DestroyBothItems();
        }
        switch (MergeItem.ItemColor) {
            case "Red":
                Instantiate(PurpleItemPrefab, MergeItem.gameObject.transform.position, Quaternion.identity);
                DestroyBothItems();
                break;
            case "Yellow":
                Instantiate(GreenItemPrefab, MergeItem.gameObject.transform.position, Quaternion.identity);
                DestroyBothItems();
                break;
            case "Green":
                Instantiate(NavyItemPrefab, MergeItem.gameObject.transform.position, Quaternion.identity);
                DestroyBothItems();
                break;
        }
    }
}
