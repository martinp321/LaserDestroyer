using UnityEngine;
using System.Collections;

public class Enemy : FiringLogic
{

    // Use this for initialization
    void Start()
    {
        //InvokeRepeating("Fire", .000001f, firingRate);
    }

    // Update is called once per frame
    void Update()
    {
        float probability = Time.deltaTime * firingRate;

        if (Random.value < probability)
        {
            Fire();
        }
    }
}
