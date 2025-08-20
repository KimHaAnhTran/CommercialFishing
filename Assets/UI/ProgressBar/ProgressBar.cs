using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private float maximum;
    public float current;
    
    [SerializeField] private Image fill;

    [Header("The End")]
    public GameObject lastCutscene;


    // Start is called before the first frame update
    private void Start()
    {
        lastCutscene.SetActive(false);
        current = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        increaseProgress();
        getCurrentFill();
        if(current >= maximum)
        {
            lastCutscene.SetActive(true);
        }
    }

    private void getCurrentFill()
    {
        float fillAmount = current / maximum;
        fill.fillAmount = fillAmount;
    }

    private void increaseProgress()
    {
        current += Time.deltaTime;
    }

}
