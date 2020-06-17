using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMOve : MonoBehaviour
{
    public static PlayerMOve p;
    private float velocity = 100f;
    private Transform targetpos;
    public GameObject[] tiles;
    public bool isplayermoving;
    private bool resetile;
    public bool isplayer2turn;
    public bool selecttile;
    
    void Start()
    {
       
        p = this;
        WalkableTile(); 
       
        
    }

    // Update is called once per frame
    private void Update()
    {
        
           
           if(isplayer2turn)
           {
                WalkableTile();
           }
                
           

    }

    private void FixedUpdate()
    {

        if(isplayer2turn)
            Move(targetpos);

    }



    public IEnumerator delaytomove()
    {


        isplayermoving = true;

        yield return new WaitForSeconds(2f);
       // targetpos.GetComponent<Tile>().target = false;      
        isplayermoving = false;
        gameObject.transform.position = new Vector3(targetpos.position.x, gameObject.transform.position.y, PlayerMOve.p.targetpos.position.z);
        yield return new WaitForSeconds(.5f);
        isplayer2turn = false;
        Player1.p1.isplayer1turn = true;
        CanvasScript.c.turnoatual++;

    }

    public void Move(Transform cell)
    {
        if (isplayer2turn == true)
        {
            if(selecttile == true)
            {
                targetpos = cell;
                targetpos.GetComponent<Tile>().target = true;
                targetpos.GetComponent<Tile2>().target = true;
               // FindObjectOfType<soundManager>().Play("playermovement");
                gameObject.transform.position = Vector3.Lerp(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), new Vector3(cell.transform.position.x, gameObject.transform.position.y, cell.transform.position.z), 0.1f * Time.deltaTime * velocity);
                StartCoroutine(disabletarget(targetpos.transform));
            }
              




        }
            


    }
    #region walkabletile
    public void WalkableTile()
    {
       
            for (int i = 0; i < 63; i++)
            {
                
                if ((gameObject.gameObject.transform.position.x - tiles[i].transform.position.x) <= 3 && (gameObject.transform.position.x - tiles[i].transform.position.x) >= -3 && (tiles[i].transform.position.z == gameObject.transform.position.z))
                {
                   
                        tiles[i].GetComponent<Tile>().selectable = true;
                        tiles[i].GetComponent<Tile2>().selectable = true;
                        tiles[i].GetComponent<Tile>().current = false;
                        tiles[i].GetComponent<Tile2>().current = false;



                 }
                else if ((gameObject.transform.position.z - tiles[i].transform.position.z) <= 3 && (gameObject.transform.position.z - tiles[i].transform.position.z) >= -3 && (tiles[i].transform.position.x == gameObject.transform.position.x))
                {
                    tiles[i].GetComponent<Tile>().selectable = true;
                    tiles[i].GetComponent<Tile2>().selectable = true;
                    tiles[i].GetComponent<Tile>().current = false;
                    tiles[i].GetComponent<Tile2>().current = false;





            }
            else if ((gameObject.transform.position.x - tiles[i].transform.position.x) <= 3 && (gameObject.transform.position.x - tiles[i].transform.position.x) >= -3 && (gameObject.transform.position.z - tiles[i].transform.position.z) <= 3 && (gameObject.transform.position.z - tiles[i].transform.position.z) >= -3)
                {
                    if ((gameObject.transform.position.x - tiles[i].transform.position.x > 0) && (gameObject.transform.position.z - tiles[i].transform.position.z > 0))
                    {
                        if ((gameObject.transform.position.x - tiles[i].transform.position.x) == (gameObject.transform.position.z - tiles[i].transform.position.z))
                        {

                            tiles[i].GetComponent<Tile>().selectable = true;
                            tiles[i].GetComponent<Tile2>().selectable = true;
                            tiles[i].GetComponent<Tile>().current = false;
                            tiles[i].GetComponent<Tile2>().current = false;




                    }
                }
                    else if ((gameObject.transform.position.x - tiles[i].transform.position.x < 0) && (gameObject.transform.position.z - tiles[i].transform.position.z < 0))
                    {
                        if ((gameObject.transform.position.x - tiles[i].transform.position.x) == (gameObject.transform.position.z - tiles[i].transform.position.z))
                        {
                            tiles[i].GetComponent<Tile>().selectable = true;
                            tiles[i].GetComponent<Tile2>().selectable = true;
                            tiles[i].GetComponent<Tile>().current = false;
                            tiles[i].GetComponent<Tile2>().current = false;




                    }
                }
                    else if ((gameObject.transform.position.x - tiles[i].transform.position.x > 0) && (gameObject.transform.position.z - tiles[i].transform.position.z < 0))
                    {
                        if ((((gameObject.transform.position.z - tiles[i].transform.position.z)) * -1) - (gameObject.transform.position.x - tiles[i].transform.position.x) == 0)
                        {

                            tiles[i].GetComponent<Tile>().selectable = true;
                            tiles[i].GetComponent<Tile2>().selectable = true;
                            tiles[i].GetComponent<Tile>().current = false;
                            tiles[i].GetComponent<Tile2>().current = false;




                    }
                }
                    else if ((gameObject.transform.position.x - tiles[i].transform.position.x < 0) && (gameObject.transform.position.z - tiles[i].transform.position.z > 0))
                    {
                        if ((((gameObject.transform.position.x - tiles[i].transform.position.x)) * -1) - (gameObject.transform.position.z - tiles[i].transform.position.z) == 0)
                        {

                            tiles[i].GetComponent<Tile>().selectable = true;
                            tiles[i].GetComponent<Tile2>().selectable = true;
                            tiles[i].GetComponent<Tile>().current = false;
                            tiles[i].GetComponent<Tile2>().current = false;




                        }
                    }
                }
            }
      
    }
    #endregion

    IEnumerator disabletarget(Transform target)
    {
        
        yield return new WaitForSeconds(1f);
        target.GetComponent<Tile>().target = false;
        target.GetComponent<Tile2>().target = false;

    }
}





