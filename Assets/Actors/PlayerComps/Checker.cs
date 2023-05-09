using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    List<GameObject> currentTarget = new List<GameObject>();
    [SerializeField]
    Transform Parent;
    [SerializeField]
    Transform selfTrans;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.selfTrans.position = Parent.position;
    }
    public void fire(double damage){
        foreach(var thing in currentTarget){
            if(thing.tag == "Enemy"){
                thing.GetComponent<enemy>().fire(damage);
                return;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D box){
        Debug.Log("Enemy in our sights.");
        currentTarget.Add(box.gameObject);
    }
    void OnTriggerExit2D(Collider2D box){
        Debug.Log("Enemy not in our sights.");
        currentTarget.Remove(box.gameObject);
    }


}
