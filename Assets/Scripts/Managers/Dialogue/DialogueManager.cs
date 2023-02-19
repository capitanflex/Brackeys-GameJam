using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameUI;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Animator _animator;
    
    private Queue<string> sentences;
    private Queue<string> names;

    public bool isLastDialogue;

    private GameManager _gameManager;
    
    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        sentences = new Queue<string>();
        names = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        _gameManager.CanMove(false);
        sentences.Clear();
        
        _animator.SetBool("isOpen", true);

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach (string name in dialogue.name)
        {
            names.Enqueue(name);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();

        _nameUI.text = name;
        
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        _text.text = "";
        foreach (char lettter in sentence.ToCharArray())
        {
            _text.text += lettter;
            yield return null;
        }
    }

    private void EndDialogue()
    {
        _animator.SetBool("isOpen", false);
        _gameManager.CanMove(true);
        if (isLastDialogue)
        { 
            _gameManager.BackToMenu();
        }
        
    }

    
}
