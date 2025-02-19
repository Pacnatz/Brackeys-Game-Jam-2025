using UnityEngine;

public class YellowItem : BaseItem {

    public GameObject OrangeItemPrefab;
    public GameObject GreenItemPrefab;
    public GameObject LimeItemPrefab;
    public GameObject TanItemPrefab;

    private void Awake() {
        ItemColor = "Yellow";
    }


    public override void Merge() {
        if (MergeItem.ItemColor == ItemColor) {
            DestroyBothItems();
        }
        switch (MergeItem.ItemColor) {
            case "Red":
                Instantiate(OrangeItemPrefab, MergeItem.gameObject.transform.position, Quaternion.identity);
                DestroyBothItems();
                break;
            case "Blue":
                Instantiate(GreenItemPrefab, MergeItem.gameObject.transform.position, Quaternion.identity);
                DestroyBothItems();
                break;
            case "Green":
                Instantiate(LimeItemPrefab, MergeItem.gameObject.transform.position, Quaternion.identity);
                DestroyBothItems();
                break;
            case "Purple":
                Instantiate(TanItemPrefab, MergeItem.gameObject.transform.position, Quaternion.identity);
                DestroyBothItems();
                break;
        }
    }

}
