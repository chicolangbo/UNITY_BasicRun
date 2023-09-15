using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(!GameManager.Instance.IsGameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}