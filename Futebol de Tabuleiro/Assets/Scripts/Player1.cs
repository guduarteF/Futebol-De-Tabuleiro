using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{

    public static Player1 p1;
    private float velocity = 100f;
    public Transform targetpos;
    public GameObject[] tiles;
    public bool isplayermoving;
    private bool resetile;
    public bool isplayer1turn;
    

    void Start()
    {
        
        p1 = this;
        isplayer1turn = true;

    }

    // Update is called once per frame
    private void Update()
    {
        
        WalkableTile();

    }

    private void FixedUpdate()
    {
        if(isplayer1turn)
            Move(targetpos);

    }




    public void Move(Transform cell)
    {
        //if (isplayer1turn == true)
        //{
            if (cell.GetComponent<Tile2>().current == true)
            {
                targetpos = cell;
                gameObject.transform.position = Vector3.Lerp(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), new Vector3(cell.transform.position.x, gameObject.transform.position.y, cell.transform.position.z), 0.1f * Time.deltaTime * velocity);

            }
        //}




    }

    public void WalkableTile()
    {
        for (int i = 0; i < 63; i++)
        { 
           
                if ((gameObject.gameObject.transform.position.x - tiles[i].transform.position.x) <= 3 && (gameObject.transform.position.x - tiles[i].transform.position.x) >= -3 && (tiles[i].transform.position.z == gameObject.transform.position.z))
                {
                    if (tiles[i].GetComponent<Tile2>().changedcolorred == false)
                    {
                        tiles[i].GetComponent<Tile>().current = true;
                        tiles[i].GetComponent<Tile>().changedcolorblue = true;

                    }
                    


                }
                else if ((gameObject.gameObject.transform.position.z - tiles[i].transform.position.z) <= 3 && (gameObject.transform.position.z - tiles[i].transform.position.z) >= -3 && (tiles[i].transform.position.x == gameObject.transform.position.x))
                {
                    if (tiles[i].GetComponent<Tile2>().changedcolorred == false)
                    {
                        tiles[i].GetComponent<Tile2>().current = true;
                        tiles[i].GetComponent<Tile>().changedcolorblue = true;

                    }
                    
                }
                else if ((gameObject.transform.position.x - tiles[i].transform.position.x) <= 3 && (gameObject.transform.position.x - tiles[i].transform.position.x) >= -3 && (gameObject.gameObject.transform.position.z - tiles[i].transform.position.z) <= 3 && (gameObject.transform.position.z - tiles[i].transform.position.z) >= -3)
                {
                    if ((gameObject.transform.position.x - tiles[i].transform.position.x > 0) && (gameObject.transform.position.z - tiles[i].transform.position.z > 0))
                    {
                        if ((gameObject.transform.position.x - tiles[i].transform.position.x) == (gameObject.transform.position.z - tiles[i].transform.position.z))
                        {
                            if (tiles[i].GetComponent<Tile2>().changedcolorred == false)
                            {
                                tiles[i].GetComponent<Tile2>().current = true;
                                tiles[i].GetComponent<Tile>().changedcolorblue = true;

                            }
                        }
                    }
                    else if ((gameObject.transform.position.x - tiles[i].transform.position.x < 0) && (gameObject.transform.position.z - tiles[i].transform.position.z < 0))
                    {
                        if ((gameObject.transform.position.x - tiles[i].transform.position.x) == (gameObject.transform.position.z - tiles[i].transform.position.z))
                        {
                            if (tiles[i].GetComponent<Tile2>().changedcolorred == false)
                            {
                                tiles[i].GetComponent<Tile2>().current = true;
                                tiles[i].GetComponent<Tile>().changedcolorblue = true;

                            }
                        }
                    }
                    else if ((gameObject.transform.position.x - tiles[i].transform.position.x > 0) && (gameObject.transform.position.z - tiles[i].transform.position.z < 0))
                    {
                        if ((((gameObject.transform.position.z - tiles[i].transform.position.z)) * -1) - (gameObject.transform.position.x - tiles[i].transform.position.x) == 0)
                        {
                            if (tiles[i].GetComponent<Tile2>().changedcolorred == false)
                            {
                                tiles[i].GetComponent<Tile2>().current = true;
                                tiles[i].GetComponent<Tile>().changedcolorblue = true;

                            }
                        }
                    }
                    else if ((gameObject.transform.position.x - tiles[i].transform.position.x < 0) && (gameObject.transform.position.z - tiles[i].transform.position.z > 0))
                    {
                        if ((((gameObject.transform.position.x - tiles[i].transform.position.x)) * -1) - (gameObject.transform.position.z - tiles[i].transform.position.z) == 0)
                        {
                            if (tiles[i].GetComponent<Tile2>().changedcolorred == false)
                            {
                                tiles[i].GetComponent<Tile2>().current = true;
                                tiles[i].GetComponent<Tile>().changedcolorblue = true;

                            }
                        }

                    }
                }
            
        }
    }
}
