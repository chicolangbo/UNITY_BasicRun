using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacles;
    private bool stepped = false;

    private void OnEnable()// ���������� �����
    {
        stepped = false;
        foreach(var go in obstacles)
        {
            go.SetActive(Random.value < 0.3f); // 0.0~1.0���� �� ���� -> 30%�� Ȯ���� true
        }
    }

    // Start is called before the first frame update
    void Start() // ù ������Ʈ ����Ǳ� ������ �����
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
