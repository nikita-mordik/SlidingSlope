using UnityEngine;

public class TreeAndRock : MonoBehaviour
{
    public float speed = 1.5f;

    public AudioSource crashAudio;

    private void Start()
    {
        Destroy(gameObject, 15f);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        //скорость передвижени€ объектов в зависимости от колличества набраных очков:
        var number = GameController.Instance.Score;
        switch (number)
        {
            case 5:
                speed = .3f;
                break;
            case 10:
                speed = .5f;
                break;
            case 15:
                speed = .7f;
                break;
            case 20:
                speed = .9f;
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
        else
        {
            //если пересеклось с колайдером друг дргуа, то мен€ю позицию объекта у другого колайдера
            RaycastHit2D hit;
            hit = Physics2D.BoxCast(transform.position, transform.localScale, 0f, new Vector2(0, -1), .5f);
            if (hit)
            {
                print(hit.collider.name);
                print(gameObject.name);
                //transform.position = (hit.transform.position - new Vector3(hit.transform.position.x, hit.transform.position.y - 2));
                hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y - 2f);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision)
        {
            print("in stay - " + collision.name);
            transform.position = new Vector3(transform.position.x, transform.position.y - 2f);
        }
    }
}