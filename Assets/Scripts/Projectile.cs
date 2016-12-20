using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float damage { get { return 100f; } }

    public void Hit()
    {
        Destroy(gameObject);
    }


}
