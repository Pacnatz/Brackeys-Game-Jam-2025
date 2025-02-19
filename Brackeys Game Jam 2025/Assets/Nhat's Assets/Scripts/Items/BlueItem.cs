using UnityEngine;

public class BlueItem : BaseItem {

    public GameObject PurpleItemPrefab;
    public GameObject GreenItemPrefab;
    public GameObject NavyItemPrefab;


    private void Awake() {
        ItemColor = "Blue";
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
