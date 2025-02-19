using UnityEngine;

public class OliveItem : BaseItem {

    private void Awake() {
        ItemColor = "Olive";
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
