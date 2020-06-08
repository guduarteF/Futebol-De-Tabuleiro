using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public static Tile t;
    public bool wakable = true;
    public bool current = false;
    public bool target = false;
    public bool selectable = false;
    public bool startfirstmovement;
    private bool playerismoving;
    
    void Start()
    {
        t = this;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (current)
        {
            GetComponent<Renderer>().material.color = Color.magenta;
        }
        else if(target)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else if(selectable)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }

    void OnMouseDown()
    {
        
       if(PlayerMOve.p.isplayermoving == false)
       {
            target = true;
            PlayerMOve.p.Move(gameObject.transform);
            StartCoroutine(delaytomove());
       }

    }

    IEnumerator delaytomove()
    {
        PlayerMOve.p.isplayermoving = true;
        yield return new WaitForSeconds(1.5f);
        target = false;
        PlayerMOve.p.isplayermoving = false;

    }



}
