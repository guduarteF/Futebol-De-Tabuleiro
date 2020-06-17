using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile2 : MonoBehaviour
{
    public static Tile2 t2;  
    public bool wakable = true;
    public bool current = false;
    public bool target = false;
    public bool selectable = false;
    public bool startfirstmovement;
    private bool playerismoving;
   
   

    void Start()
    {
        t2 = this;
    }

    // Update is called once per frame
    void Update()
    {

        if (current)
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
        else if (target)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else if (selectable)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }


    }

    void OnMouseDown()
    {
        if(Player1.p1.isplayer1turn == true)
        {
            if (Player1.p1.isplayermoving == false)
            {
                
                if (current == true)
                {
                    playerismoving = true;
                    FindObjectOfType<soundManager>().Play("clickp2");
                    Player1.p1.selecttile = true;
                    Player1.p1.Move(gameObject.transform);
                    StartCoroutine(Player1.p1.delaytomove());
                }
                
            }
        }
      

    }

   

}
