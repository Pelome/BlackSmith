using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnThief_Script : MonoBehaviour
{
    //public float Timer = 2;
    public GameObject Thief;
    GameObject thiefClone;
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 3f;
    private float nextSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time + GetRandomSpawnInterval();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnThief();
            nextSpawnTime = Time.time + GetRandomSpawnInterval();
        }
    }

    public void SpawnThief()
    {
        int currentGold = GameManager.instance.GetCurrentGold();
        if(currentGold >=1)
        {
            thiefClone = Instantiate(Thief, gameObject.transform.position, transform.rotation) as GameObject;
        }
    }


    private float GetRandomSpawnInterval()
    {
        return Random.Range(minSpawnInterval, maxSpawnInterval);
    }
}
