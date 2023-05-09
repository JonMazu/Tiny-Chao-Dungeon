using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class actor: MonoBehaviour
{
    [SerializeField]
    string actorName;
    //0:Swim = Defense 1:Fly = Dodge 2:Run = Turn Timer? 3:Pow = Base Damage 4:Stam = Health
    [SerializeField]
    List<int> skillLevel; //0-99
    [SerializeField]
    List<double> skillPower; //0-9999
    [SerializeField]
    List<int> skillRating; //A-B-C-D
    [SerializeField]
    SpriteRenderer sprite;
    [SerializeField]
    Transform Posi;
    [SerializeField]
    Transform BodyPosi;
    [SerializeField]
    Camera playerView;
    double maxHealth,health;
    [SerializeField]
    TextMeshProUGUI playerUI;
    [SerializeField]
    Checker getter;



    // Start is called before the first frame update
    void Start()
    {   
        maxHealth = 20*(System.Math.Ceiling(skillPower[4]/10));
        Debug.Log(skillPower[4]);
        Debug.Log(skillPower[4]/10);
        health = maxHealth;

    }
    void OnTriggerEnter2D(Collider2D box){
        Debug.Log("We HIT!");
        if(box.gameObject.tag == "Enemy"){
            health -= box.gameObject.GetComponent<enemy>().getDamage();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space")){
            getter.fire(this.getDamage());
        }
        if(Input.GetKeyDown("a")){
            this.Posi.Translate(new Vector3(-1,0,0));
            this.BodyPosi.rotation = Quaternion.Euler(0, 0, 180);
        }
        if(Input.GetKeyDown("w")){
            this.Posi.Translate(new Vector3(0,1,0));
            this.BodyPosi.rotation = Quaternion.Euler(0, 0, 90);
        }
        if(Input.GetKeyDown("s")){
            this.Posi.Translate(new Vector3(0,-1,0));
            this.BodyPosi.rotation = Quaternion.Euler(0, 0, 270);
        }
        if(Input.GetKeyDown("d")){
            this.Posi.Translate(new Vector3(1,0,0));
            this.BodyPosi.rotation = Quaternion.Euler(0, 0, 0);
        }
        playerUI.text = "HP:"+health+"/"+maxHealth;
    }

    public double getDamage(){
        return 2+(System.Math.Ceiling(skillPower[3]/10));
    }
    
}
