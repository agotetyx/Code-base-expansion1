using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum GameState {
    PreRound,
    Playing,
    GameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    public TextMeshProUGUI messageOverlayObject;
    public GameObject scroll;
    public GameState current_state;
    public GameObject menuBtn;

    public int juggle_counter;
    public int fail_counter;
    public int juggles_to_make_happy;
    public int fails_to_make_angry;

    public KingBehavior king_script;

    private void Awake()
    {
        if (GameManager.Singleton)
        {
            Destroy(this.gameObject);
        } else 
        {
            Singleton = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {   
        // SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
        // king_script = king.GetComponent<KingBehavior>();
        start_new_game();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void start_new_game()
    {
        // SceneManager.LoadScene("objDrop", LoadSceneMode.Single);
        // Set current_state to PreRound
        current_state = GameState.PreRound;

        // Reset counters
        juggle_counter = 0;
        fail_counter = 0;
        
        // Call get_ready function
        get_ready();
    }

    void get_ready()
    {
        // telling player game is about to start
        
    
        //  Countdown and Call start_game
        StartCoroutine(CountdownToStart());

    
        
    }
    IEnumerator CountdownToStart()
    {
        scroll.SetActive(true);
        menuBtn.SetActive(false);
        float currentTime = 3.0f;
        messageOverlayObject.text = "Get Ready!";
        yield return new WaitForSeconds(2.0f);

        while (currentTime > 0)
        {
            messageOverlayObject.text = currentTime.ToString("F0"); 
            yield return new WaitForSeconds(1.0f); 
            currentTime--;
        }

        messageOverlayObject.text = "";
        scroll.SetActive(false);
        start_game();
    }

    void start_game()
    {
        // Set current_state to Playing
        Debug.Log("about to start!!!!!!!!!");
        current_state = GameState.Playing;
        // Call function to start dropping items

    }

    public void update_hits(int points, string counter)
    {
        // Update respective counter
        if (counter == "juggle")
        {
            juggle_counter++;
        } else if (counter == "fail")
        {
            fail_counter++;
        }

        // Update King's Emotion
        if (juggle_counter >= juggles_to_make_happy)
        {
            juggle_counter = 0;
            king_script.update_king_emotion("happier");
        } else if (fail_counter >= fails_to_make_angry)
        {
            fail_counter = 0;
            king_script.update_king_emotion("angrier");
        }
    }

    public void game_over(bool won)
    {
        // Set current_state to GameOver
        current_state = GameState.GameOver;
        scroll.SetActive(true);
        menuBtn.SetActive(true);

        // Determine if won or lost and tell players through text
        if (won)
        {
            messageOverlayObject.text = "You made me laugh!";
            Debug.Log("YOU WON");
        } else
        {
            messageOverlayObject.text = "You made me outraged!";
            Debug.Log("YOU LOST");
        }

        // Have button to go back to menu
    }
    

}
