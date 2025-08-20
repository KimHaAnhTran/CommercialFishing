using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>(); 
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.SetBool("hover", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        anim.SetBool("hover", false);
    }


}
