using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{

    public GameObject target, audioObject;
    [SerializeField] private float speed = 1f, maxLightTime = 1f;
    //[SerializeField] private AudioSource enemySplashSFX;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isMoving = true, waitUntilDispel = false;
    private float lightTime = 0f;


    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();        
    }
    private void Update()
    {
        if (isMoving)
        {
            lightTime = 0f;
            Vector3 pos = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            rb.MovePosition(pos);
        }
        if (waitUntilDispel)
        {
            lightTime += Time.deltaTime;
            if (lightTime >= maxLightTime)
            {
                anim.SetBool("dispel", true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            anim.SetBool("caught", true);
            isMoving = false;
            waitUntilDispel = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Light") && lightTime < maxLightTime)
        {
            isMoving = true;
            anim.SetBool("caught", false);
        }
    }

    private void destroyObject()
    {
        //Destroy(transform.parent.gameObject);
        Destroy(gameObject);
    }

    private void playSplashSound()
    {
        GameObject audioFile = Instantiate(audioObject, transform.position, Quaternion.identity);
        Destroy(audioFile, 3f);
        //AudioSource.PlayClipAtPoint(enemySplashSFX, transform.position);
        Debug.Log("Why isn't it playing?");
        //AudioSource.PlayClipAtPoint(enemySplashSFX, transform.position);
    }

}
