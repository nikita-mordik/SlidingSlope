using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Vector2 direction;

    private Vector2 minBorder;
    private Vector2 maxBorder;

    public AudioSource pickAudio;

    public GameObject sled;

    private void Start()
    {
        direction = Vector2.zero;
        minBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxBorder = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        StartCoroutine(StartMoving());
    }

    private void Update()
    {
        ChangeDirectionOnTouch();
    }

    private void FixedUpdate()
    {
        Move();
        //if (transform.position.x > maxBorder.x - transform.localScale.x / 2)// || transform.position.x < minBorder.x + transform.localScale.x / 2)
        //{//права€ часть экрана
        //    print("change direction");

        //    direction *= -1f;
        //}
        //else if(transform.position.x < minBorder.x + transform.localScale.x / 2)
        //{//лева€ часть экрана
        //    print("asdasd");
        //    direction *= -1f;
        //}
    }

    IEnumerator StartMoving()
    {
        direction = Vector2.down;

        yield return new WaitForSeconds(.8f);

        direction = Vector2.right;
    }

    void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        //провер€ю на столкновение с границей экрана:
        //if (Mathf.Abs(transform.position.x) + transform.localScale.x / 1.5f > maxBorder.x
        //    || Mathf.Abs(transform.position.x) - transform.localScale.x / 1.5f > maxBorder.x)
        //{
        //    direction = new Vector2(-direction.x, direction.y);
        //    var newScale = transform.localScale.x;
        //    newScale *= -1f;
        //    transform.localScale = new Vector3(newScale, 1, 1);
        //}

        if (transform.position.y > 1f)  //двигаю игрока по оси у до определЄнного значени€
        {
            transform.Translate(new Vector2(transform.position.x, -transform.position.y) * Time.fixedDeltaTime * 0.1f);
        }
        else if (transform.position.y < 1f)
        {
            transform.position = new Vector2(transform.position.x, 1f);
        }
    }

    private void ChangeDirectionOnTouch()
    {
        if (Input.touchCount > 0)  //при касании мен€ю направление
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase== TouchPhase.Began)
            {
                if (direction == Vector2.down || direction == Vector2.left)
                {
                    direction = Vector2.right;
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else if (direction == Vector2.right)
                {
                    direction = Vector2.left;
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            if (direction == Vector2.down || direction == Vector2.left)
            {
                direction = Vector2.right;
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (direction == Vector2.right)
            {
                direction = Vector2.left;
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)  //проверка на столкновение с границей экрана
    {
        if (collision.CompareTag("Border"))
        {
            direction = new Vector2(-direction.x, direction.y);
            var newScale = transform.localScale.x;
            newScale *= -1f;
            transform.localScale = new Vector3(newScale, 1, 1);
        }

        if (collision.GetComponent<Flag>())
        {
            pickAudio.Play();
        }
    }
}