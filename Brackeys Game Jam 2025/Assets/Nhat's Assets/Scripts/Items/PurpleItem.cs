using UnityEngine;

public class PurpleItem : BaseItem {

    private void Awake() {
        ItemColor = "Purple";
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
                Debug.Log("Purple");
                DestroyBothItems();
                break;
            */
        }
    }

}
