using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menumanager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StarGame()
    {
        SceneManager.LoadScene("SampleScene");
        FindObjectOfType<soundManager>().Play("start");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
