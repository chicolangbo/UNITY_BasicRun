using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public int count = 3;

    private float spawnTimeMin = 1.25f;
    private float spawnTimeMax = 2.25f;
    private float spawnTime;

    public float xPos = 20f;
    public float yMin = -3.5f;
    public float yMax = 1.5f;

    private GameObject[] platforms;
    private int currentIndex = 0;

    private Vector2 poolPosition = new Vector2(0f, -25f);
    private float lastSpawnTime;

    // Start is called before the first frame update
    private void Start()
    {
        platforms = new GameObject[count];

        for(int i = 0; i < count; ++i)
        {
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);
        }

        lastSpawnTime = 0f;
        spawnTime = 0f;
    }

    // Update is called once per frame
    private void Update()
    {
        if(GameManager.Instance.IsGameOver)
        {
            return;
        }

        if(Time.time > lastSpawnTime + spawnTime)
        {
            lastSpawnTime = Time.time;
            spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);

            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);

            var y = Random.Range(yMin, yMax);
            platforms[currentIndex].transform.position = new Vector2(xPos, y);

            currentIndex++;
            if(currentIndex >= count)
            {
                currentIndex = 0;
            }
        }
    }
}
