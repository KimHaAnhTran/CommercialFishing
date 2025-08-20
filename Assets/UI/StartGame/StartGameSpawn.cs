using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameSpawn : MonoBehaviour
{
    public GameObject UIStart;
    public GameObject enemySpawner;
    private void Start()
    {
        UIStart.SetActive(true);
        enemySpawner.SetActive(true);
    }
}

