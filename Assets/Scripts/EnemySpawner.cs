using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float delayBetweenSpawns;

    public float width = 10f;
    public float height = 5f;
    public float speed = 4f;

    private enum Directions { LEFT, RIGHT };
    private Directions direction;

    private float minX, maxX;
    private float offset;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(CreateSpawns());

        offset = (width / 2);

        minX = Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f)).x;
        maxX = Camera.main.ViewportToWorldPoint(new Vector2(1f, 0f)).x;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector2(width, height));
    }

    private IEnumerator CreateSpawns()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
            yield return new WaitForSeconds(delayBetweenSpawns);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float leftMost = transform.position.x - offset;
        float rightMost = transform.position.x + offset;

        if (leftMost <= minX)
        {
            direction = Directions.RIGHT;
        }
        else if (rightMost >= maxX)
        {
            direction = Directions.LEFT;
        }

        switch (direction)
        {
            case Directions.LEFT:
                transform.position += Vector3.left * speed * Time.deltaTime;
                break;

            case Directions.RIGHT:
                transform.position += Vector3.right * speed * Time.deltaTime;
                break;
        }
    }
}
