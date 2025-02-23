using UnityEngine;

public class YellowItem : BaseItem {

    public GameObject OrangeItemPrefab;
    public GameObject GreenItemPrefab;
    public GameObject LimeItemPrefab;
    public GameObject TanItemPrefab;

    private void Awake() {
        ItemColor = "Yellow";
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
            case "Yellow":
                return true;
            case "Red":
                return true;
            case "Blue":
                return true;
            case "Green":
                return true;
            case "Purple":
                return true;
        }
        return false;
    }

    public override void Merge() {
        if (MergeItem.ItemColor == ItemColor) {
            float chance = Random.Range(0, 100);
            if (chance > successChance) {
                FindFirstObjectByType<AudioManager>().Play("SplatAudio");
                splashScript.StartSplash(Color.yellow);
            }
            else {
                FindFirstObjectByType<AudioManager>().Play("DamageAudio");
                bossScript.TakeDamage(damage, Color.yellow);
            }
            DestroyBothItems();
            
        }

        else
        {
            FindFirstObjectByType<AudioManager>().Play("CombinationAudio");
        }



        switch (MergeItem.ItemColor) {
            case "Red":
                Instantiate(OrangeItemPrefab, MergeItem.gameObject.transform.position, Quaternion.identity);
                DestroyBothItems();
                break;
            case "Blue":
                Instantiate(GreenItemPrefab, MergeItem.gameObject.transform.position, Quaternion.identity);
                DestroyBothItems();
                break;
            case "Green":
                Instantiate(LimeItemPrefab, MergeItem.gameObject.transform.position, Quaternion.identity);
                DestroyBothItems();
                break;
            case "Purple":
                Instantiate(TanItemPrefab, MergeItem.gameObject.transform.position, Quaternion.identity);
                DestroyBothItems();
                break;
        }
    }

}
