using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private AudioSource clickAudio;
    public void OnPointerClick(PointerEventData eventData)
    {
        clickAudio.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
