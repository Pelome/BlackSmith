using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControler : MonoBehaviour
{
public Text goldInStash;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goldInStash.text = GameManager.instance.GetCurrentGold().ToString();
    }
}
