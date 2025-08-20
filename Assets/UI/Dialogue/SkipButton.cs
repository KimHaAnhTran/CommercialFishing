using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkipButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject startGame, avatar1, avatar2;
    public void OnPointerClick(PointerEventData eventData)
    {
        startGame.SetActive(true);
        avatar1.SetActive(false);
        avatar2.SetActive(false);
        gameObject.transform.parent.gameObject.SetActive(false);
    }

   
}
