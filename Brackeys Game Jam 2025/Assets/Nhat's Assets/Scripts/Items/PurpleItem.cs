using UnityEngine;

public class PurpleItem : BaseItem {

    public GameObject TanItemPrefab;
    private void Awake() {
        ItemColor = "Purple";
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
            case "Purple":
                return true;
            case "Yellow":
                return true;
        }
        return false;
    }

    public override void Merge() {
        if (MergeItem.ItemColor == ItemColor) {
            DestroyBothItems();
        }
        switch (MergeItem.ItemColor) {
            case "Yellow":
                Instantiate(TanItemPrefab, MergeItem.gameObject.transform.position, Quaternion.identity);
                DestroyBothItems();
                break;
        }
    }

}
