using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private GameObject particles;
    [SerializeField] private GameObject particlesFloorDestruction;
    [SerializeField] private GameObject visual;
    [SerializeField] private AudioClip destructionAudioClip;

    private int health = 3; 

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "PlayerArms") 
        {
            health = health - 1;
            if (health != 0) GetComponent<AudioSource>().PlayOneShot(audioClip);
        }

        if (health == 0) 
        {
            visual.SetActive(false);
            particles.GetComponent<ParticleSystem>().Play();
            GetComponent<AudioSource>().PlayOneShot(destructionAudioClip, 0.5f);
            StartCoroutine(ExecuteAfterTime(1f));
        }

        if (col.transform.tag == "Floor")
        {
            GameManager.Singleton.update_hits(1, "fail");
            visual.SetActive(false);
            particlesFloorDestruction.GetComponent<ParticleSystem>().Play();
            GetComponent<AudioSource>().PlayOneShot(destructionAudioClip, 0.5f);
            StartCoroutine(ExecuteAfterTime(1f));
        }
    }

    private IEnumerator ExecuteAfterTime(float time) 
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
