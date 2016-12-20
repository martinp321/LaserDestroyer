using UnityEngine;
using System.Collections;

public class FiringLogic : MonoBehaviour
{
    public GameObject smokePrefab;
    public GameObject laserPrefab;
    public int fireDirection = 1;
    public float firingRate;

    public float health = 101f;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (gameObject.tag == "Laser" && collider.tag == "Enemy Laser") return;

        if (collider.tag == "Laser")
        {
            Projectile laser = collider.GetComponent<Projectile>();
            if (laser)
            {
                health -= laser.damage;
                laser.Hit();
                if (health <= 0)
                {
                    Instantiate(smokePrefab, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
            }
        }

        if (collider.tag == "Enemy Laser")
        {
            print("player hit by enemy");
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fire()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity += new Vector2(0f, 10f * fireDirection);
    }
}
