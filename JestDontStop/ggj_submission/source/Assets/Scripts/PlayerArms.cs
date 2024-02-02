using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArms : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject ropeVis;
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (player.IsPunching()) {
            Debug.Log("Juggle item!");
            GameManager.Singleton.update_hits(1, "juggle");
        }

        if (col.transform.tag == "power")
        {
            Invoke("SetFalse", 0.5f);
        }

    }
 // disable after 5 seconds

    void SetFalse()

    {
        ropeVis.GetComponent<SpriteRenderer>().enabled = false;
        player.playerDistLimit = 20;
        Invoke("SetTrue", 5.0f);


    }
     void setTrue()
    {
        player.playerDistLimit = 7;
        ropeVis.GetComponent<SpriteRenderer>().enabled = true;
    }
}
