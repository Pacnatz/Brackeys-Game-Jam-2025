using UnityEngine;

public class BrownItem : BaseItem {

    private void Awake() {
        ItemColor = "Brown";
    }


    public override void Merge() {
        if (MergeItem.ItemColor == ItemColor) {
            DestroyBothItems();
        }
        switch (MergeItem.ItemColor) {
            case "":
                break;

        }
    }

}
