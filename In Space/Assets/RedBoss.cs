using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class RedBoss : EnemyShip {

    public Transform[] Barrels;
    public GameObject[] Bullets;
    public float Reload;
    public float PillReload;


    private float ReloadTimer;
    private float PillTimer;

	// Use this for initialization
	void Start () {
        StartCoroutine(FlightPath());
	}
	
	// Update is called once per frame
	void Update () {
        if (Reload <= ReloadTimer)
        {
            for (int i = 0; i < Barrels.Length-1; i++)
            {
                var clone = Instantiate(Bullets[0], Barrels[i].position, Bullets[0].transform.rotation) as GameObject;
                clone.GetComponent<Rigidbody2D>().AddForce(Barrels[i].up * 300);
                if (i > 0 && Health.HealthAmount / (float)Health.MaxHealth > .9) break;
                if (i > 2 && Health.HealthAmount / (float)Health.MaxHealth > .8) break;
                if (i > 4 && Health.HealthAmount / (float)Health.MaxHealth > .7) break;
                if (i > 6 && Health.HealthAmount / (float)Health.MaxHealth > .6) break;
            }
            ReloadTimer = 0;
        }
        else
        {
            ReloadTimer += Time.deltaTime;
        }

        if(PillReload <= PillTimer)
        {
            Debug.Log(Health.HealthAmount / (float)Health.MaxHealth);
            if (Health.HealthAmount / (float)Health.MaxHealth <= .3)
            {
                var clone = Instantiate(Bullets[1], Barrels[8].position, Bullets[1].transform.rotation) as GameObject;
                clone.GetComponent<Rigidbody2D>().AddForce(Barrels[8].up * 300);
                Destroy(clone, 2f);
                PillTimer = 0;
            }
        }
        else
        {
            PillTimer += Time.deltaTime;
        }
	}

    IEnumerator FlightPath()
    {
        GoTo = (Vector2)transform.position + new Vector2(-5, 0);
        yield return new WaitUntil(() => (Vector2)transform.position == GoTo);
        while (true)
        {
            GoTo = (Vector2)transform.position + new Vector2(-2, 0);
            yield return new WaitUntil(() => (Vector2)transform.position == GoTo);
            GoTo = (Vector2)transform.position + new Vector2(2, 2);
            yield return new WaitUntil(() => (Vector2)transform.position == GoTo);
            GoTo = (Vector2)transform.position + new Vector2(2, -2);
            yield return new WaitUntil(() => (Vector2)transform.position == GoTo);
            GoTo = (Vector2)transform.position + new Vector2(-2, -2);
            yield return new WaitUntil(() => (Vector2)transform.position == GoTo);
            GoTo = (Vector2)transform.position + new Vector2(-2, 2);
            yield return new WaitUntil(() => (Vector2)transform.position == GoTo);
            GoTo = (Vector2)transform.position + new Vector2(2, 0);
            yield return new WaitUntil(() => (Vector2)transform.position == GoTo);
        }
    }
}
