using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private int chance;
    private bool endDestroy = false, shouldSpawn = true;
    private float timer = 0f, xPos, yPos;
    [SerializeField] private float maxTime = 2f;
    public GameObject enemy;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxTime && shouldSpawn)
        {
            spawnEnemy();
            timer = 0f;
        }

        if (endDestroy)
        {
            Destroy(GameObject.FindWithTag("Enemy"));
        }
        
    }

    private void spawnEnemy()
    {
        chance = Random.Range(0, 5);
        if(chance == 0)
        {
            spawnLeft();
        }else if (chance == 1)
        {
            spawnUp();
        }else if (chance == 2)
        {
            spawnRight();
        }
        else
        {
            spawnDown();
        }
        transform.position = new Vector2(xPos, yPos);
        Instantiate(enemy, transform.position,Quaternion.identity);
    }

    private void spawnLeft()
    {
        yPos = Random.Range(-6.5f, 6.5f);
        xPos = -14f;
    }
    private void spawnRight()
    {
        yPos = Random.Range(-6.5f, 6.5f);
        xPos = 14f;
    }
    private void spawnUp()
    {
        yPos = 14f;
        xPos = Random.Range(-12.5f, 12.5f);
    }
    private void spawnDown()
    {
        yPos = -14f;
        xPos = Random.Range(-12.5f, 12.5f);
    }

    public void destroyAllEnemies()
    {
        /*GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject go in objectsToDestroy)
        {
            Destroy(go);
        }*/
        shouldSpawn = false;
        endDestroy = true;
    }

    public void destroySelf()
    {
        Destroy(gameObject);
    }
}
