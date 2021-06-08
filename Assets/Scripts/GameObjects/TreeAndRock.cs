using UnityEngine;

public class TreeAndRock : MonoBehaviour
{
    public float speed = 1.5f;

    public AudioSource crashAudio;
    Rigidbody2D misc_rigidbody;
    LayerMask misc;

    private void Start()
    {
        misc_rigidbody = GetComponent<Rigidbody2D>();
        misc = LayerMask.GetMask("Misc");
        Destroy(gameObject, 30f);
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit2DUp = Physics2D.Raycast(misc_rigidbody.position + Vector2.up * 0.5f, transform.TransformDirection(Vector2.up), 1.1f, misc);
        if (hit2DUp)
        {
            hit2DUp.transform.position = new Vector3(hit2DUp.transform.position.x, hit2DUp.transform.position.y - 4.5f);
        }

        RaycastHit2D hit2DRight = Physics2D.Raycast(misc_rigidbody.position + Vector2.right * 0.5f, transform.TransformDirection(Vector2.right), 1.1f, misc);
        if (hit2DRight)
        {
            hit2DRight.transform.position = new Vector3(hit2DRight.transform.position.x + .3f, hit2DRight.transform.position.y + 1f);
        }

        RaycastHit2D hit2DLeft = Physics2D.Raycast(misc_rigidbody.position + Vector2.left * 0.5f, transform.TransformDirection(Vector2.left), 1.1f, misc);
        if (hit2DLeft)
        {
            hit2DLeft.transform.position = new Vector3(hit2DLeft.transform.position.x - .3f, hit2DLeft.transform.position.y + 1f);
        }

        //RaycastHit2D hit2DDown = Physics2D.Raycast(misc_rigidbody.position + Vector2.down * 0.8f, transform.TransformDirection(Vector2.down), 1f, misc);
        //if (hit2DDown)
        //{
        //    print("down");
        //    hit2DDown.transform.position = new Vector3(hit2DDown.transform.position.x, hit2DDown.transform.position.y - 1.5f);
        //}

        transform.Translate(Vector2.up * speed * Time.deltaTime);

        //скорость передвижения объектов в зависимости от колличества набраных очков:
        var number = GameController.Instance.Score;
        switch (number)
        {
            case 5:
                speed = .2f;
                break;
            case 10:
                speed = .3f;
                break;
            case 15:
                speed = .5f;
                break;
            case 20:
                speed = .8f;
                break;
            case 30:
                speed = 1.2f;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            crashAudio.Play();
            Destroy(collision.gameObject);
            GameController.IsLose = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 2f);
        }
    }
}