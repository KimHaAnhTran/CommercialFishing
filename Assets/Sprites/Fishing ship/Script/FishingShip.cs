using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingShip : MonoBehaviour
{

    [SerializeField] private Camera cam;
    [SerializeField] private float shakeStrength = 0.75f, maxShakeDuration = 0.3f; //For when ship is hit by monsters
    [SerializeField] private AudioSource impactAudio;
    private bool shake = false, hasShaken = false;
    private float shakeTime = 0f;
    public GameObject loseCutscene;

    void Start()
    {
        loseCutscene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        updateShake();
    }

    
    private void updateShake()
    {
        if (shake)
        {
            
            cameraShake();
            shakeTime += Time.deltaTime;
            if (shakeTime >= maxShakeDuration)
            {  
                loseCutscene.SetActive(true);
                shake = false;
                cameraShake();
                shakeTime = 0f;
            }
        }
        else
        {
            return;
        }
    }

    private void cameraShake()
    {
        if (shake)
        {
            float randomX = Random.value - 0.5f;
            float randomY = Random.value - 0.5f;

            cam.transform.localEulerAngles = new Vector3(randomX, randomY, 0) * shakeStrength;
        }
        else if (!shake)
        {
            cam.transform.localEulerAngles = new Vector3(0, 0, 0);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !hasShaken) {
            impactAudio.Play();
            shake = true;
            hasShaken = true;
        }
    }
}
