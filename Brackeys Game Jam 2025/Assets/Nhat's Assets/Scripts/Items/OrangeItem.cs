using UnityEngine;

public class OrangeItem : BaseItem {

    public GameObject OliveItemPrefab;

    private void Awake() {
        ItemColor = "Orange";
    }


    public override void Merge() {
        if (MergeItem.ItemColor == ItemColor) {
            DestroyBothItems();
        }
        switch (MergeItem.ItemColor) {
            case "Green":
                Instantiate(OliveItemPrefab, MergeItem.gameObject.transform.position, Quaternion.identity);
                DestroyBothItems();
                break;
        }
    }

}
