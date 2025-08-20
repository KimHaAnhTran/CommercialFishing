using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject cutscene;
    [SerializeField] private AudioSource clickAudio;

    public void OnPointerClick(PointerEventData eventData)
    {
        clickAudio.Play();
        cutscene.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        cutscene.SetActive(false);
    }

}
