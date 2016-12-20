using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public GameObject laserPrefab;
    public float padding = 1f;
    public float firingRate;

    private Rigidbody2D body;
    private static float speed = 5f;
    private Vector2 moveLeft;
    private Vector2 moveRight;
    private Vector2 moveUp;
    private Vector2 moveDown;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    // Use this for initialization
    void Start()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        minX = Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f)).x + padding;
        maxX = Camera.main.ViewportToWorldPoint(new Vector2(1f, 0f)).x - padding;

        minY = Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f)).y + padding;
        maxY = Camera.main.ViewportToWorldPoint(new Vector2(0f, 1f)).y - padding;

        body = GetComponent<Rigidbody2D>();
        moveLeft = Vector2.left * speed * Time.deltaTime;
        moveRight = Vector2.right * speed * Time.deltaTime;
        moveUp = Vector2.up * speed * Time.deltaTime;
        moveDown = Vector2.down * speed * Time.deltaTime;


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", .000001f, firingRate);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            body.velocity += moveLeft;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            body.velocity += moveRight;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            body.velocity += moveUp;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            body.velocity += moveDown;
        }

        float xPos = Mathf.Clamp(transform.position.x, minX, maxX);
        float yPos = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector2(xPos, yPos);
    }

    private void Fire()
    {
        Vector3 vectorOffset = new Vector3(0f, -0.7f, 0f);
        GameObject laser = Instantiate(laserPrefab, transform.position - vectorOffset, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity += new Vector2(0f, 10f);
    }
}
