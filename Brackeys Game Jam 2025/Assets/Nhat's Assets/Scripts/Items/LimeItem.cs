using UnityEngine;

public class LimeItem : BaseItem {

    private void Awake() {
        ItemColor = "Lime";
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // If the dragged item goes into trigger assign the this to the mergingItem

        collision.TryGetComponent<BaseItem>(out var selectedItem);
        if (selectedItem) {
            if (selectedItem.getIsSelected() && selectedItem.MergeItem == null) {
                if (!onConveyor) {
                    if (CheckMerge(selectedItem)) {
                        selectedItem.MergeItem = this;
                        highlightCircle.SetActive(true);
                    }
                }
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision) {
        // Assign MergeItem to null

        collision.TryGetComponent<BaseItem>(out var selectedItem);
        if (selectedItem) {
            if (selectedItem.getIsSelected() && selectedItem.MergeItem == this) {
                if (!onConveyor) {
                    selectedItem.MergeItem = null;
                    highlightCircle.SetActive(false);
                }
            }
        }

    }

    private bool CheckMerge(BaseItem selectedItem) {
        switch (selectedItem.ItemColor) {
            case "Lime":
                return true;
        }
        return false;
    }

    public override void Merge() {
        if (MergeItem.ItemColor == ItemColor) {
            float chance = Random.Range(0, 100);
            if (chance > successChance) {
                FindFirstObjectByType<AudioManager>().Play("SplatAudio");
                splashScript.StartSplash(new Color32(0, 255, 0, 255));
            }
            else {
                bossScript.TakeDamage(damage, new Color32(0, 255, 0, 255));
                FindFirstObjectByType<AudioManager>().Play("DamageAudio");
            }
            DestroyBothItems();
            
        }


        else
        {
            FindFirstObjectByType<AudioManager>().Play("CombinationAudio");
        }


        switch (MergeItem.ItemColor) {
            case "":
                break;

        }
    }

}
