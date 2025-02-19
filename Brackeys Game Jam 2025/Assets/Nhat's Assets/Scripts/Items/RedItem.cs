using UnityEngine;

public class RedItem : BaseItem {

    public GameObject PurpleItemPrefab;
    public GameObject OrangeItemPrefab;

    private void Awake() {
        ItemColor = "Red";
    }


    public override void Merge() {
        if (MergeItem.ItemColor == ItemColor) {
            DestroyBothItems();
        }
        switch (MergeItem.ItemColor) {
            case "Blue":
                Instantiate(PurpleItemPrefab, MergeItem.gameObject.transform.position, Quaternion.identity);
                DestroyBothItems();
                break;
            case "Yellow":
                Instantiate(OrangeItemPrefab, MergeItem.gameObject.transform.position, Quaternion.identity);
                DestroyBothItems();
                break;
        }
    }

}
