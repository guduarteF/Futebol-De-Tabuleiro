using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMOve : MonoBehaviour
{
    public static PlayerMOve p;
    private float velocity = 30f;
    private Transform targetpos;
    public GameObject[] tiles;
    public bool isplayermoving;
    
    void Start()
    {
       
        p = this;
       
        
    }

    // Update is called once per frame
    private void Update()
    {
        WalkableTile();
    }

    private void FixedUpdate()
    {
        
            if (gameObject.transform.position.x != targetpos.position.x && gameObject.transform.position.z != targetpos.position.z)
            {
                Move(targetpos);
            }
        
      
               
        
      
    }

  

    
    public void Move(Transform cell)
    {      
            gameObject.transform.position = Vector3.Lerp(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), new Vector3(cell.transform.position.x, gameObject.transform.position.y, cell.transform.position.z), 0.1f * Time.deltaTime * velocity);
            targetpos = cell;


    }

    public void WalkableTile()
    {
       for(int i = 0; i < 63; i++)
       {
            if(tiles[i].gameObject.transform.position.x < gameObject.transform.position.x + 3 && tiles[i].gameObject.transform.position.z < gameObject.transform.position.z + 3)
            {
                tiles[i].GetComponent<Tile>().selectable = true;

                
                
            }
            else
            {
                tiles[i].GetComponent<Tile>().selectable = false;
            }
           
       }
    }

}
           
   
     
    

