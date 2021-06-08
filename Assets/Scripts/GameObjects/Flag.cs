using UnityEngine;

public class Flag : MonoBehaviour
{
    public float speed = 2f;

    private void Start()
    {
        Destroy(gameObject, 30f);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        //скорость передвижени€ объектов в зависимости от колличества набраных очков:
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
            Destroy(gameObject);
            GameController.Instance.Score++;
        }
        else
        {
            //если пересеклось с колайдером друг дргуа, то мен€ю позицию объекта у другого колайдера
            RaycastHit2D hit;
            hit = Physics2D.BoxCast(transform.position, transform.localScale, 0f, new Vector2(1, 0), .5f);
            if (hit)
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }
}