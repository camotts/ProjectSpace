using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveController : MonoBehaviour {

    public GameObject[] Enemies;
    public List<GameObject> ActiveEnemies;


	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnWaves());
	}
	
	// Update is called once per frame
	void Update () {
        ActiveEnemies.RemoveAll(x => x == null);
	}

    IEnumerator SpawnWaves()
    {
        yield return new WaitUntil(() => ActiveEnemies.Count == 0 );
        Debug.Log("Spawn Wave 1");
        Instantiate(Enemies[0], new Vector3(10, 0, 0), Enemies[0].transform.rotation);
        Instantiate(Enemies[0], new Vector3(10, 1, 0), Enemies[0].transform.rotation);
        Instantiate(Enemies[0], new Vector3(10, -1, 0), Enemies[0].transform.rotation);
        Instantiate(Enemies[0], new Vector3(10, 2, 0), Enemies[0].transform.rotation);
        Instantiate(Enemies[0], new Vector3(10, -2, 0), Enemies[0].transform.rotation);
        yield return new WaitUntil(() => ActiveEnemies.Count == 0);
        Debug.Log("Spawn Wave 2");
        Instantiate(Enemies[0], new Vector3(10, 0, 0), Enemies[0].transform.rotation);
        Instantiate(Enemies[0], new Vector3(10, 1, 0), Enemies[0].transform.rotation);
        Instantiate(Enemies[0], new Vector3(10, -1, 0), Enemies[0].transform.rotation);
        Instantiate(Enemies[0], new Vector3(10, 2, 0), Enemies[0].transform.rotation);
        Instantiate(Enemies[0], new Vector3(10, -2, 0), Enemies[0].transform.rotation);
        Instantiate(Enemies[1], new Vector3(10, 0, 0), Enemies[1].transform.rotation);
        yield return new WaitUntil(() => ActiveEnemies.Count == 0);
        yield return new WaitForSeconds(3);
        Instantiate(Enemies[3], new Vector3(11, 0, 0), Enemies[3].transform.rotation);
    }
}
