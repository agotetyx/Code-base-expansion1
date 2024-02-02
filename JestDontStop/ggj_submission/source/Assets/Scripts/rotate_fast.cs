using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_fast : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 90f; 
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {
        
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        
        
    }
    
}
