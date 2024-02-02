using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objGen : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb; 
    public GameObject spawnedObject;
    public GameObject randomPrefab;
    public GameObject[] prefabs;

    public float spawnXPosition = 0f; 
    public float min_x;
    public float max_x;

    public float spawnInterval = 2f; 
    private float nextSpawnTime;
    public GameObject itemsParent;
    private int maxItemCount = 0;

    void Start()
    {   
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {   

        if (Time.time > nextSpawnTime && GameManager.Singleton.current_state==GameState.Playing){
            
            switch (GameManager.Singleton.king_script.current_emotion)
            {
                case KingEmotion.Frustrated:
                    maxItemCount = 2;
                    break;
                case KingEmotion.Discontent:
                    maxItemCount = 3;
                    break;
                case KingEmotion.Neutral:
                    maxItemCount = 4;
                    break;
                case KingEmotion.Satisfactory:
                    maxItemCount = 5;
                    break;
                case KingEmotion.Joy:
                    maxItemCount = 6;
                    break;
                default:
                    maxItemCount = 3; 
                    break;
            }
            if (itemsParent.transform.childCount >= maxItemCount){
                Debug.Log("stop Generate");
                return ;
            }
            randomPrefab = prefabs[Random.Range(0, prefabs.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(min_x, max_x),6f, 0f);
            spawnedObject = Instantiate(randomPrefab, spawnPosition, Quaternion.identity);
            
            spawnedObject.transform.parent = itemsParent.transform;
            // Debug.Log("number: ");
            // Debug.Log(itemsParent.childCount);
            rb = spawnedObject.GetComponent<Rigidbody>();

            if (rb!= null){
                Debug.Log(rb.position.y);
                Debug.Log(rb.useGravity);
                Debug.Log(rb.position.y);
                if(rb.position.y < -5f){
                    // Debug.Log("here!");
                    // Destroy(spawnedObject, 2.0f);
                } else {
                    rb.useGravity = true;
                    rb.mass = 2.0f;
                }
            }
            nextSpawnTime = Time.time + spawnInterval;

        }

        
    }
}


