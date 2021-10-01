using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castlePNJ_Spawner : MonoBehaviour
{
    public int ufoSpeed;
    public float Timer = 2;
    public GameObject pnj;
    public GameObject castleDoor;
    public Sprite doorOpen;
    public Sprite doorClose;
    public GameObject destPosition;
    GameObject pnjClone;
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
            SpawnPnj();

            Timer = 5f;
        }
     
    }

    public void SpawnPnj()
    {
        castleDoor.gameObject.GetComponent<SpriteRenderer>().sprite = doorOpen;
        //Instantiate(pnj, gameObject.transform);
        pnjClone = Instantiate(pnj, gameObject.transform.position, transform.rotation) as GameObject;
        //add delay
        StartCoroutine (delayDoor());
    }

    IEnumerator delayDoor()
    {
        yield return new WaitForSeconds(.6f);
            
        castleDoor.gameObject.GetComponent<SpriteRenderer>().sprite = doorClose;

        yield return new WaitForEndOfFrame();
    }

}

