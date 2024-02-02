using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{   


    void Start()
    {
        
    }
    void Update()
    {
        
    }
    // Start is called before the first frame update
    public void btn_QuitGame()
    {
        Application.Quit();
    }

    public void btn_StartNewGame()
    {
        
        SceneManager.LoadScene("FinalGameScene");
        // GameManager.Singleton.start_new_game();
    }
    public void btn_Credits()
    {
        
        SceneManager.LoadScene("Credits");
        // GameManager.Singleton.start_new_game();
    }
    public void btn_back()
    {
        
        SceneManager.LoadScene("Menu");
        // GameManager.Singleton.start_new_game();
    }

    
    


}
