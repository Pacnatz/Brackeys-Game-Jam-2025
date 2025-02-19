using UnityEngine;

public class OrangeItem : BaseItem {

    private void Awake() {
        ItemColor = "Orange";
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
                Debug.Log("Orange");
                DestroyBothItems();
                break;
            */
        }
    }

}
