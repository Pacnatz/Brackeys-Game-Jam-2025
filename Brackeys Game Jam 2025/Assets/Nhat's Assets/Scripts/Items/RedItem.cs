using UnityEngine;

public class RedItem : BaseItem {

    public GameObject PurpleItemPrefab;
    public GameObject OrangeItemPrefab;
    public GameObject BrownItemPrefab;

    private void Awake() {
        ItemColor = "Red";
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
            case "Red":
                return true;
            case "Blue":
                return true;
            case "Yellow":
                return true;
            case "Green":
                return true;
        }
        return false;
    }

    public override void Merge() {
        if (MergeItem.ItemColor == ItemColor) {
            
            float chance = Random.Range(0, 100);
            if (chance > successChance) {
                FindFirstObjectByType<AudioManager>().Play("SplatAudio");
                splashScript.StartSplash(Color.red);
            }
            else {
                FindFirstObjectByType<AudioManager>().Play("DamageAudio");
                bossScript.TakeDamage(damage, Color.red);
            }
            DestroyBothItems();
            
        }

        else
        {
            FindFirstObjectByType<AudioManager>().Play("CombinationAudio");
        }



        switch (MergeItem.ItemColor) {
            case "Blue":
                Instantiate(PurpleItemPrefab, MergeItem.gameObject.transform.position, Quaternion.identity);
                DestroyBothItems();
                break;
            case "Yellow":
                Instantiate(OrangeItemPrefab, MergeItem.gameObject.transform.position, Quaternion.identity);
                DestroyBothItems();
                break;
            case "Green":
                Instantiate(BrownItemPrefab, MergeItem.gameObject.transform.position, Quaternion.identity);
                DestroyBothItems();
                break;
        }
    }

}
