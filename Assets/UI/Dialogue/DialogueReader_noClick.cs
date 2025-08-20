using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueReader_noClick : DialogueBaseClass
    {
        private TMP_Text textHolder;

        [Header("Text Options")]
        [SerializeField] private string[] dialogueList;

        [Header("Time Parameters")]
        [SerializeField] private float delay;
        private int i = 0;
        private string input;

        [Header("Audio Source")]
        [SerializeField] private AudioSource typeSound;

        private void Awake()
        {
            gameObject.SetActive(true);
            textHolder = GetComponent<TMP_Text>();
            StartCoroutine(startNewDialogue());
        }

        private IEnumerator startNewDialogue()
        {
            foreach (string line in dialogueList)
            {
                yield return StartCoroutine(WriteText_noClick(dialogueList[i], textHolder, delay, typeSound));
                i++;
            }
            gameObject.SetActive(false);
        }

    }
}