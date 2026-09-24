using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : TienMonoBehaviour
{
    [SerializeField] protected float speed = 2f;

    private void Update()
    {
        transform.parent.Translate(speed * Vector2.up * Time.deltaTime);
    }
}
