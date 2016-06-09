using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Health Health;
    public GameObject Bullet;
    public GameObject PowerUp;
    public Transform Barrel;
    public float Reload;
    public int Lives = 3;
    public float PowerUpTime;

    private float ReloadTimer;
    private ScoreController ScoreController;
    private bool IsDead;

    void Awake()
    {
        ScoreController = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<ScoreController>();
        Health = GetComponent<Health>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead) return;
        if (Reload <= ReloadTimer)
        {
            if (Input.GetButton("Fire1"))
            {
                GameObject clone;
                if (PowerUp != null && PowerUp.tag == Tags.Bullet)
                {
                    clone = Instantiate(PowerUp, Barrel.transform.position, PowerUp.transform.rotation) as GameObject;
                }
                else
                {
                    clone = Instantiate(Bullet, Barrel.transform.position, Bullet.transform.rotation) as GameObject;
                }

                clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(400, 0));
                ReloadTimer = 0;
                ScoreController.ShotsFired++;
            }
        }
        else
        {
            ReloadTimer += Time.deltaTime;
        }
        if(PowerUp != null)
        {
            StartCoroutine(DestroyPowerUp());
        }
    }

    void FixedUpdate()
    {
        if (IsDead) return;
        Vector3 newPos = new Vector3();
        newPos.y = transform.position.y + (Input.GetAxis("Vertical") * .15f);
        newPos.x = transform.position.x + (Input.GetAxis("Horizontal") * .15f);



        var bounds = this.GetComponentInChildren<SpriteRenderer>().sprite.bounds;
        if (newPos.x > 9 - bounds.extents.x) newPos.x = 9 - bounds.extents.x;
        if (newPos.x <= -9 + bounds.extents.x) newPos.x = -9 + bounds.extents.x;
        if (newPos.y > 5 - bounds.extents.y) newPos.y = 5 - bounds.extents.y;
        if (newPos.y <= -5 + bounds.extents.y) newPos.y = -5 + bounds.extents.y;
        transform.position = newPos;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer(Layers.Enemy))
        {
            if (col.tag == Tags.Bullet)
            {
                Health.HealthAmount -= col.gameObject.GetComponent<Bullet>().Damage;
                Destroy(col.gameObject);
            }

        }
    }

    public IEnumerator Death()
    {
        ToggleDeadState();
        yield return new WaitForSeconds(5);
        transform.position = new Vector2(-8, 0);
        ToggleDeadState();
    }

    void ToggleDeadState()
    {
        IsDead = !IsDead;
        GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
        foreach (var col in GetComponents<Collider>())
        {
            col.enabled = !col.enabled;
        }
    }

    IEnumerator DestroyPowerUp()
    {
        yield return new WaitForSeconds(PowerUpTime);
        PowerUp = null;
    }
}
