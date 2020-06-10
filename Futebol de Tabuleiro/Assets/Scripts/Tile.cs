﻿using System.Collections;
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
    public bool changedcolorblue;
    
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
                target = true;
                PlayerMOve.p.Move(gameObject.transform);
                StartCoroutine(delaytomove());
            }
        }
      

    }

    IEnumerator delaytomove()
    {
         
                              
        PlayerMOve.p.isplayermoving = true;
       
        yield return new WaitForSeconds(1f);        
        target = false;
        PlayerMOve.p.isplayermoving = false;
        PlayerMOve.p.gameObject.transform.position = new Vector3(PlayerMOve.p.targetpos.position.x, PlayerMOve.p.transform.position.y, PlayerMOve.p.targetpos.position.z);
        PlayerMOve.p.isplayer2turn = false; 
        Player1.p1.isplayer1turn = true;


    }



}
