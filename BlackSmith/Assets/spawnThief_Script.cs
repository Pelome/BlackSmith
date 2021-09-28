using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnThief_Script : MonoBehaviour
{
    public float Timer = 2;
    public GameObject Thief;
    GameObject thiefClone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            SpawnThief();

            Timer = 5f;
        }
    }

    public void SpawnThief()
    {
        thiefClone = Instantiate(Thief, gameObject.transform.position, transform.rotation) as GameObject;
    }
}
