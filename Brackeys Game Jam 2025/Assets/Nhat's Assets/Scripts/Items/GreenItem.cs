using UnityEngine;

public class GreenItem : BaseItem {

    public GameObject BrownItemPrefab;
    public GameObject NavyItemPrefab;
    public GameObject LimeItemPrefab;
    public GameObject OliveItemPrefab;

    private void Awake() {
        ItemColor = "Green";
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
            case "Green":
                return true;
            case "Red":
                return true;
            case "Blue":
                return true;
            case "Yellow":
                return true;
            case "Orange":
                return true;
        }
        return false;
    }

    public override void Merge() {
        if (MergeItem.ItemColor == ItemColor) {
            float chance = Random.Range(0, 100);
            if (chance > successChance) {
                FindFirstObjectByType<AudioManager>().Play("SplatAudio");
                splashScript.StartSplash(Color.green);
            }
            else {
                bossScript.TakeDamage(damage, Color.green);
                FindFirstObjectByType<AudioManager>().Play("DamageAudio");
            }

            
            DestroyBothItems();
        }

        else
        {
            FindFirstObjectByType<AudioManager>().Play("CombinationAudio");
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
        }
    }

}
