using UnityEngine;

public class LimeItem : BaseItem {

    private void Awake() {
        ItemColor = "Lime";
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
