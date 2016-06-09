using UnityEngine;
using System.Collections;

public class SpinningBullet : Bullet {

    private Animator Anim;

    void Awake()
    {
        Anim = GetComponent<Animator>();
        Anim.SetBool("SpinningBullet", true);
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
