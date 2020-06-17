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
    public bool selecttile;
    public bool countableblue, countablered, countablewhite;

    
    
    void Start()
    {
        t = this;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (current)
        {
            GetComponent<Renderer>().material.color = Color.blue;
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
        if(PlayerMOve.p.isplayer2turn == true)
        {
            if (PlayerMOve.p.isplayermoving == false)
            {
                
                if(selectable == true)
                {
                    playerismoving = true;
                    FindObjectOfType<soundManager>().Play("clickp1");
                    PlayerMOve.p.selecttile = true;
                    PlayerMOve.p.Move(gameObject.transform);
                    StartCoroutine(PlayerMOve.p.delaytomove());
                }
               
                
            }
        }
      

    }

   



}
