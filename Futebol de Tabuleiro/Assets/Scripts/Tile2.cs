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
    public bool changedcolorred;

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
                target = true;
                Player1.p1.Move(gameObject.transform);
                StartCoroutine(delaytomove());
            }
        }
      

    }

    IEnumerator delaytomove()
    {
        Player1.p1.isplayermoving = true;

        yield return new WaitForSeconds(1f);
        target = false;
        Player1.p1.isplayermoving = false;
        Player1.p1.gameObject.transform.position = new Vector3(Player1.p1.targetpos.position.x, Player1.p1.transform.position.y, Player1.p1.targetpos.position.z);
        Player1.p1.isplayer1turn = false;
        PlayerMOve.p.isplayer2turn = true;
    }

}
