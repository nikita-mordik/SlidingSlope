using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(new Vector2(0, -0.1f) * Time.deltaTime * 8.5f);
    }
}