using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

    public GameObject PowerUpObj;
    public float Time;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != Tags.Player) return;
        col.gameObject.GetComponent<PlayerController>().PowerUp = PowerUpObj;
        col.gameObject.GetComponent<PlayerController>().PowerUpTime = Time;
        Destroy(this.gameObject);
    }
}
