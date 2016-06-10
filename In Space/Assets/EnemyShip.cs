using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

public class EnemyShip : MonoBehaviour
{
    public int Points = 100;
    public Health Health;
    public float Speed = 1;
    protected Vector2 GoTo;
    protected Renderer Render;
    protected bool CanFire;

    public void Awake()
    {
        GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<WaveController>().ActiveEnemies.Add(this.gameObject);
        Render = GetComponent<Renderer>();
        Health = GetComponent<Health>();
    }

    void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, GoTo, (1 / (20 * (Vector3.Distance(gameObject.transform.position, GoTo))))*Speed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer(Layers.Player))
        {
            GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<ScoreController>().ShotsHit++;
            if(col.tag == Tags.Bullet)
            {
                Health.HealthAmount -= col.gameObject.GetComponent<Bullet>().Damage;
                Destroy(col.gameObject);
            }
        }
    }

    public IEnumerator Death()
    {
        Health.HealthAmount++;
        Destroy(this.gameObject);
        yield return new WaitForSeconds(5);
    }
}

