using UnityEngine;

public class NavyItem : BaseItem {

    private void Awake() {
        ItemColor = "Navy";
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
