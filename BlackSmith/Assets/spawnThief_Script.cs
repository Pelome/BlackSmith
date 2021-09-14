using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnThief_Script : MonoBehaviour
{
    public GameObject Thief;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnThief()
    {
        Instantiate(Thief, gameObject.transform);
    }
}
