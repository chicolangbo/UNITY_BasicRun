using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacles;
    private bool stepped = false;

    private void OnEnable()// 켜질때마다 실행됨
    {
        stepped = false;
        foreach(var go in obstacles)
        {
            go.SetActive(Random.value < 0.3f); // 0.0~1.0사이 값 랜덤 -> 30%의 확률로 true
        }
    }

    // Start is called before the first frame update
    void Start() // 첫 업데이트 실행되기 직전에 실행됨
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !stepped)
        {
            stepped = true;
            GameManager.Instance.AddScore(1);
        }
    }
}
