using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float health = 101f;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Laser")
        {
            Projectile laser = collider.GetComponent<Projectile>();
            if (laser)
            {
                health -= laser.damage;
                laser.Hit();
                if (health <= 0)
                {
                    Destroy(gameObject);
                }
            }
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
}
