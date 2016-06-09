using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

public class Health: MonoBehaviour
{
    public int HealthAmount = 100;
    public int MaxHealth = 100;

    void Update()
    {
        if(HealthAmount <= 0)
        {
            if (gameObject.tag == Tags.Player) {
                StartCoroutine(gameObject.GetComponent<PlayerController>().Death());
                gameObject.GetComponent<PlayerController>().Lives--;
                HealthAmount = MaxHealth;
            }
            else if(gameObject.tag == Tags.Enemy)
            {
                StartCoroutine(gameObject.GetComponent<EnemyShip>().Death());
                GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<ScoreController>().Score += gameObject.GetComponent<EnemyShip>().Points;
            }
            
        }
    }

}

