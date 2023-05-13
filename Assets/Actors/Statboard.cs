using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Statboard : MonoBehaviour
{
    [SerializeField]
    actor player;
    [SerializeField]
    GameObject StatText;
    [SerializeField]
    TextMeshProUGUI ActorText;
    [SerializeField]
    TextMeshProUGUI FlyText;
    [SerializeField]
    TextMeshProUGUI SwimText;
    [SerializeField]
    TextMeshProUGUI RunText;
    [SerializeField]
    TextMeshProUGUI PowText;
    [SerializeField]
    TextMeshProUGUI StaminaText;
    List<int> tempLevel;
    List<double> TempPow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempLevel = player.getLevel();
        TempPow = player.getPower();
        ActorText.text ="Name: "+ player.getName();
        FlyText.text = "Fly: Lvl "+tempLevel[0]+" : Power "+TempPow[0]; 
        SwimText.text = "Swim: Lvl "+tempLevel[1]+" : Power "+TempPow[1]; 
        RunText.text = "Run: Lvl "+tempLevel[2]+" : Power "+TempPow[2]; 
        PowText.text = "Pow: Lvl "+tempLevel[3]+" : Power "+TempPow[3]; 
        StaminaText.text = "Stamina: Lvl "+tempLevel[4]+" : Power "+TempPow[4]; 

    }
}
