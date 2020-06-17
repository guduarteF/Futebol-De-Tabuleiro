using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public GameObject text, img;
    public RawImage bluesize, redsize, whitesize;
    public Text canvasText;
    private int blueturn, redturn;
    public GameObject[] celulas;
    private int totalcell = 63 , bluecell , redcell , whitecell;
    public Text turnos;
    public int turnoatual;
    public static CanvasScript c;
    public Text playerxwins;
    public GameObject canvasendgame;
    void Start()
    {
        
        c = this;
        text.SetActive(false);
        img.SetActive(false);
        totalcelulas();
    }

    // Update is called once per frame
    void Update()
    {
        if (turnoatual == 11)
        {
            canvasendgame.SetActive(true);
            //FindObjectOfType<soundManager>().Play("endgame");
            if (bluecell > redcell)
            {
                playerxwins.text = "Player Blue Wins";
            }
            else
            {
                playerxwins.text = "Player Red Wins";
                
            }

        }        
        bluesize.GetComponent<RectTransform>().sizeDelta = new Vector2(bluecell,100);
        redsize.GetComponent<RectTransform>().sizeDelta = new Vector2(redcell, 100);
        Debug.Log("bluecell :" + bluecell);
        Debug.Log("redcell :" + redcell);
        Debug.Log("whitecell :" +( (whitecell - bluecell) - redcell));
       turnos.text = "Turno : " + turnoatual +" de 11";

       
            totalcelulas();
        

        if(Player1.p1.isplayer1turn == true)
        {
            blueturn++;
            redturn = 0;           
        }
        if(blueturn == 1)
        {
            canvasText.text = "BLUE TURN";
            StartCoroutine(disablecanvas());           
        }
       if(PlayerMOve.p.isplayer2turn == true)
        {
            redturn++;
            blueturn = 0;
            
        }
       if(redturn == 1)
        {
            canvasText.text = "RED TURN";
            StartCoroutine(disablecanvas());
        }

    }

    IEnumerator disablecanvas()
    {
        GetComponent<Animator>().SetBool("canvasclip", true);
        text.SetActive(true);
        img.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        text.SetActive(false);
        img.SetActive(false);
        GetComponent<Animator>().SetBool("canvasclip", false);
    }

    void totalcelulas()
    {
        //GameObject.FindGameObjectsWithTag("Tile").Length;
        for(int i = 0; i<63;i++)
        {
            if(celulas[i].GetComponent<Tile>().current)
            {
                if (celulas[i].GetComponent<Tile>().countableblue == false)
                {
                    bluecell++;
                    celulas[i].GetComponent<Tile>().countableblue = true;
                    if(celulas[i].GetComponent<Tile>().countablered == true)
                    {
                        redcell--;
                        celulas[i].GetComponent<Tile>().countablered = false;
                    }
                }
                
                
            }
            else if (celulas[i].GetComponent<Tile>().selectable)
            {
                if(celulas[i].GetComponent<Tile>().countablered == false)
                {
                    redcell++;
                    celulas[i].GetComponent<Tile>().countablered = true;
                    if (celulas[i].GetComponent<Tile>().countableblue == true)
                    {
                        bluecell--;
                        celulas[i].GetComponent<Tile>().countableblue = false;
                    }
                }
                
            }
            else if(celulas[i].GetComponent<Tile>().current == false && celulas[i].GetComponent<Tile>().selectable == false)
            {
                if(celulas[i].GetComponent<Tile>().countablewhite == false)
                {
                    whitecell++;
                    celulas[i].GetComponent<Tile>().countablewhite = true;
                }
               
            }
        }
        

    }
}
