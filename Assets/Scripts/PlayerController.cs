using UnityEngine;
using System.Collections;

public class PlayerController : FiringLogic
{
    public float padding = 1f;

    private Rigidbody2D body;
    private static float speed = 8f;
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
        FiringMechanism();
        MovePlayer();
        CheckBoundaries();
    }

    private void FiringMechanism()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", .000001f, firingRate);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }
    }

    private void CheckBoundaries()
    {
        float xPos = Mathf.Clamp(transform.position.x, minX, maxX);
        float yPos = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector2(xPos, yPos);
    }

    private void MovePlayer()
    {
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
    }
}
