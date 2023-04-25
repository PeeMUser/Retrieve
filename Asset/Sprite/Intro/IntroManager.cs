using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IntroManager : MonoBehaviour
{
    #region Public Variables
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    public float wordSpeed;

   // public GameObject contButton;
    #endregion

    #region Private Variables
    private int index;
    #endregion

    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(PlayCutscene());

    }
    public void zeroText()
    {
        dialogueText.text = " ";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);

        }
       
        
    }
    public void NextLine()
    {
        //contButton.SetActive(false);
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
    }
    
    IEnumerator PlayCutscene()
    {
        dialoguePanel.SetActive(true);
        StartCoroutine(Typing());
        yield return new WaitForSeconds(6f);
        NextLine();
    }
}
