using UnityEngine;
using System.Collections;

public class SpiralEnemyController : EnemyShip {

    public Transform Barrel;
    public GameObject Bullet;
    public float Reload;

    private float ReloadTimer;
    private bool Toggle;


    // Use this for initialization
    void Start () {
        StartCoroutine(FlightPath());
    }
	
	// Update is called once per frame
	void Update () {
        if (!Render.isVisible) return;
        if (Reload <= ReloadTimer)
        {
            var clone = Instantiate(Bullet, Barrel.transform.position, Bullet.transform.rotation) as GameObject;
            clone.GetComponent<SpiralBullet>().SetDir(Toggle);
            Toggle = !Toggle;
            ReloadTimer = 0;
        }
        else
        {
            ReloadTimer += Time.deltaTime;
        }
	}


    IEnumerator FlightPath()
    {
        while (true)
        {
            GoTo = (Vector2)transform.position + new Vector2(-3, 0);
            yield return new WaitUntil(() => (Vector2)transform.position == GoTo);
            GoTo = (Vector2)transform.position + new Vector2(2, 0);
            yield return new WaitUntil(() => (Vector2)transform.position == GoTo);
        }
        
    }
}
