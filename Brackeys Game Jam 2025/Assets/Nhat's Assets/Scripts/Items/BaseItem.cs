using UnityEngine;

public class BaseItem : MonoBehaviour {

    protected float successChance;
    protected float failChance;

    protected bool onConveyor;
    private float conveyorPosY = -1.5f;


    private void Update() {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -100, conveyorPosY), transform.position.z);
    }

    public bool getOnConveyor() => onConveyor;
    public void setOnConveyor(bool val) { onConveyor = val; }
}
