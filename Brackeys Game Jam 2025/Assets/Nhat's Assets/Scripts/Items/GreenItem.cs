using UnityEngine;

public class GreenItem : BaseItem {

    public GameObject BrownItemPrefab;
    public GameObject NavyItemPrefab;
    public GameObject LimeItemPrefab;
    public GameObject OliveItemPrefab;

    private void Awake() {
        ItemColor = "Green";
    }


    public override void Merge() {
        if (MergeItem.ItemColor == ItemColor) {
            DestroyBothItems();
        }
        switch (MergeItem.ItemColor) {
            case "Red":
                Instantiate(BrownItemPrefab, MergeItem.gameObject.transform.position, Quaternion.identity);
                DestroyBothItems();
                break;
            case "Blue":
                Instantiate(NavyItemPrefab, MergeItem.gameObject.transform.position, Quaternion.identity);
                DestroyBothItems();
                break;
            case "Yellow":
                Instantiate(LimeItemPrefab, MergeItem.gameObject.transform.position, Quaternion.identity);
                DestroyBothItems();
                break;
            case "Orange":
                Instantiate(OliveItemPrefab, MergeItem.gameObject.transform.position, Quaternion.identity);
                DestroyBothItems();
                break;
                /*
                case "Blue":
                    Debug.Log("Green");
                    DestroyBothItems();
                    break;
                */
        }
    }

}
