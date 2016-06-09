using UnityEngine;
using System.Collections;

public class RedBoss : EnemyShip {

    public Transform[] Barrels;
    public GameObject[] Bullets;

	// Use this for initialization
	void Start () {
        StartCoroutine(FlightPath());
	}
	
	// Update is called once per frame
	void Update () {
	    foreach(var barrel in Barrels)
        {
            var clone = Instantiate(Bullets[0], barrel.position, Bullets[0].transform.rotation) as GameObject;
            clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300,0));
        }
	}

    IEnumerator FlightPath()
    {
        GoTo = (Vector2)transform.position + new Vector2(-5, 0);
        yield return new WaitUntil(() => (Vector2)transform.position == GoTo);
    }
}
