using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour
{
    TrailRenderer trail;
    public GameObject player;
    bool smt = true;
    public Vector2 originPos;

    private void Start()
    {
        trail = GetComponent<TrailRenderer>();
        originPos = transform.localPosition;
    }

    private void Update()
    {
        //StartCoroutine(Move());
        //if (smt)
        //{
        //    trail.transform.position = new Vector2(player.transform.position.x, transform.position.y + .2f);
        //    smt = false;
        //}
        //trail.AddPosition(new Vector3(player.transform.position.x,player.transform.position.y+.2f,player.transform.position.z));
        //trail.SetPosition(0, new Vector3(player.transform.position.x, player.transform.position.y + 2f, player.transform.position.z));
    }

    IEnumerator Move()
    {
        
        transform.localPosition = new Vector2(player.transform.position.x, transform.position.y + .01f);
        yield return new WaitForSeconds(.2f);
        transform.localPosition = originPos;
    }
}