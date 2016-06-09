using UnityEngine;
using System.Collections;

public class BasicEnemy : EnemyShip
{

    public GameObject Bullet;
    public Transform Barrel;
    public float Reload;

    private float ReloadTimer;


    // Use this for initialization
    void Start()
    {
        StartCoroutine(FlightPath());
    }

    // Update is called once per frame
    void Update()
    {
        if (!Render.isVisible) return;
        if (Reload <= ReloadTimer)
        {
            var clone = Instantiate(Bullet, Barrel.position, transform.rotation) as GameObject;
            clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300, 0));
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
            GoTo = (Vector2)transform.position + new Vector2(-2, 0);

            yield return new WaitUntil(() => (Vector2)transform.position == GoTo);
        }
    }

}
