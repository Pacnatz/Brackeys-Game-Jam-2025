using UnityEngine;

public class TanItem : BaseItem {

    private void Awake() {
        ItemColor = "Tan";
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
