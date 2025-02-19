using UnityEngine;

public class GreenItem : BaseItem {

    private void Awake() {
        ItemColor = "Green";
    }


    public override void Merge() {
        if (MergeItem.ItemColor == ItemColor) {
            DestroyBothItems();
        }
        switch (MergeItem.ItemColor) {
            case "":
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
