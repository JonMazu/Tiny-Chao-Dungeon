using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class enemy : MonoBehaviour
{
    [SerializeField]
    string actorName;
    //0:Swim = Defense 1:Fly = Dodge 2:Run = Turn Timer? 3:Pow = Base Damage 4:Stam = Health
    [SerializeField]
    List<int> skillLevel; //0-99
    [SerializeField]
    List<double> skillPower; //0-9999
    [SerializeField]
    SpriteRenderer sprite;
    [SerializeField]
    Transform Posi;
    double maxHealth,health;
    [SerializeField]
    TextMeshPro floatingText;
    [SerializeField]
    GameObject self;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 2*(System.Math.Ceiling(skillPower[4]/10));
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        actorName = health+"/"+maxHealth;
        floatingText.text = actorName;
        if(health == 0){
            Destroy(self);
        }
    }
    public double getDamage(){
        return 2*(System.Math.Ceiling(skillPower[3]/10));
    }
    public void fire(double damage){
        Debug.Log("I GOT HIT OW");
        health -= damage-(System.Math.Ceiling(skillPower[0]/10));
    }
    void recenter(){

    }
}
