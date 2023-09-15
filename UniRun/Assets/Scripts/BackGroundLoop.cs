using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    private float width;

    // Start is called before the first frame update
    private void Awake()
    {
        var boxCollider = GetComponent<BoxCollider2D>();
        width = boxCollider.size.x;
    }

    // Update is called once per frame
    private void Update()
    {
        if(transform.position.x < - width)
        {
            RePosition();
        }
    }

    private void RePosition()
    {
        var offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
