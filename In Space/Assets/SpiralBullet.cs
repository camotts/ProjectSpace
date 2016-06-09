using UnityEngine;
using System.Collections;

public class SpiralBullet : Bullet {

   
    private Vector2 GoTo;
    private float Dir;

	// Use this for initialization
	void Start () {
        StartCoroutine(FlightPath());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, GoTo, 1 / (20 * (Vector3.Distance(gameObject.transform.position, GoTo))));
        
    }

    public void SetDir(bool dir)
    {
        if (dir)
        {
            Dir = 1.0f;
        }
        else
        {
            Dir = -1.0f;
        }
    }

    IEnumerator FlightPath()
    {
        while (true)
        {
            for(int i = 0; i < 20; i++)
            {
                if(i <= 5)
                {
                    GoTo = (Vector2)transform.position + new Vector2(-(2 / 5f), (2 / 5f) * Dir);
                }
                else if(i >5 && i <= 10)
                {
                    GoTo = (Vector2)transform.position + new Vector2((2 / 5f), (2 / 5f) * Dir);
                }
                else if (i > 10 && i <= 15)
                {
                    GoTo = (Vector2)transform.position + new Vector2((2 / 5f), -(2 / 5f) * Dir);
                }
                else if (i <= 20)
                {
                    GoTo = (Vector2)transform.position + new Vector2(-(2 / 5f), -(2 / 5f) * Dir);
                }
                yield return new WaitUntil(() => (Vector2)transform.position == GoTo);
            }
            GoTo = (Vector2)transform.position + (new Vector2(-4f, 0));
            yield return new WaitUntil(() => (Vector2)transform.position == GoTo);

        }
        
    }
}
