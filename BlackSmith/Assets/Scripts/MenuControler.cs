using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControler : MonoBehaviour
{
public Text goldInStash;
public Text staminaInStash;
public Text dollarInStash;
public Text experienceInStash;
public Text tesIng;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goldInStash.text = GameManager.instance.GetCurrentGold().ToString();
        staminaInStash.text = GameManager.instance.GetCurrentStamina().ToString();
        dollarInStash.text = GameManager.instance.GetCurrentDollar().ToString();
        experienceInStash.text = GameManager.instance.GetCurrentExperience().ToString();
        tesIng.text = GameManager.instance.GetCurrentStep().ToString();
   }
}
