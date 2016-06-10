using UnityEngine;
using System.Collections;

public class VEnemyController : EnemyShip {

    public Transform[] Barrels;
    public GameObject Bullet;
    public float Reload;

    private float ReloadTimer;

	// Use this for initialization
	void Start () {
        StartCoroutine(FlightPath());
	}
	
	// Update is called once per frame
	void Update () {
        if (!CanFire) return;
        if (!Render.isVisible) return;
        if (Reload <= ReloadTimer)
        {
            foreach (var barrel in Barrels)
            {
                var clone = Instantiate(Bullet, barrel.position, barrel.rotation) as GameObject;
                clone.GetComponent<Rigidbody2D>().AddForce(barrel.up * 300);
            }
            ReloadTimer = 0;
        }
        else
        {
            ReloadTimer += Time.deltaTime;
        }
	}



    IEnumerator FlightPath()
    {
        GoTo = (Vector2)transform.position + new Vector2(-4, 0);
        yield return new WaitUntil(() => (Vector2)transform.position == GoTo);
        CanFire = true;
        yield return new WaitForSeconds(5);
        GoTo = (Vector2)transform.position + new Vector2(-2, 4);
        yield return new WaitUntil(() => (Vector2)transform.position == GoTo);
        while (true)
        {
            GoTo = (Vector2)transform.position + new Vector2(-2, -8);
            yield return new WaitUntil(() => (Vector2)transform.position == GoTo);
            GoTo = (Vector2)transform.position + new Vector2(-2, 8);
            yield return new WaitUntil(() => (Vector2)transform.position == GoTo);
            GoTo = (Vector2)transform.position + new Vector2(-2, -8);
            yield return new WaitUntil(() => (Vector2)transform.position == GoTo);
            GoTo = (Vector2)transform.position + new Vector2(-2, 8);
            yield return new WaitUntil(() => (Vector2)transform.position == GoTo);
        }
    }
}
