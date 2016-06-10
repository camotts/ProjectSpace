using UnityEngine;
using System.Collections;

public class PillBullet : Bullet
{

    public Transform[] Barrels;
    public GameObject Bullet;

    private bool isQuitting;
    private bool isSeen;
    private Renderer Render;

    void Awake()
    {
        Render = GetComponent<Renderer>();
    }

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().AddTorque(150f);
    }

    // Update is called once per frame
    void Update()
    {
        isSeen = Render.isVisible;
    }

    void OnApplicationQuit()
    {
        isQuitting = true;
    }

    void OnDestroy()
    {
        if (isQuitting) return;
        if (!isSeen)return;
        foreach (var barrel in Barrels)
        {
            var clone = Instantiate(Bullet, barrel.position, barrel.rotation) as GameObject;
            clone.GetComponent<Rigidbody2D>().AddForce(barrel.up * 1000);
        }
    }
}
