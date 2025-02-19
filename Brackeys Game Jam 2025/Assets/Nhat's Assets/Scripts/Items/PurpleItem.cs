using UnityEngine;

public class PurpleItem : BaseItem {

    public GameObject TanItemPrefab;
    private void Awake() {
        ItemColor = "Purple";
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
