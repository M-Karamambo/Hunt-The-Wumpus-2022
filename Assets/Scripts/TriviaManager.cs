using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class TriviaManager : MonoBehaviour
{
    public New_Trivia trivia;
    public GameObject triviaUI;

    private int questionsNeeded = 0;
    private int questionsCorrect = 0;
    private string correctAnswer = "";

    private bool finished = false;

    public Player player;

    void Start()
    {
        triviaUI.SetActive(false);
    }

    public bool LoadTrivia(int amount, int correctNeeded)
    {
        StartCoroutine(Load(amount, correctNeeded, success =>
        {
            return true;
        }));

        return false;
    }

    // Coroutine Because we need to wait until the cycle is finished
    IEnumerator Load(int amount, int correctNeeded, System.Action<bool> callBack)
    {
        player.Freeze();
        triviaUI.SetActive(true);

        finished = false;

        // Set the questionsNeeded, and start the first question
        questionsNeeded = amount;
        Next();


        // Wait until finished
        yield return new WaitUntil(() => finished);

        // Check if enough are correct
        if (questionsNeeded >= correctNeeded)
        {

            callBack(true);
        }

        // Reset Everything
        questionsNeeded = 0;
        questionsCorrect = 0;
        correctAnswer = "";

        // Set the UI inactive
        triviaUI.SetActive(false);

        player.Freeze();

        callBack(false);
    }

    void Next()
    {
        // If finished
        if (questionsNeeded == 0)
        {
            finished = true;
            return;
        }

        // Load the next question
        questionsNeeded--;
        correctAnswer = trivia.LoadRandomQuestion();
    }

    public void InputAnswer(TextMeshProUGUI answer)
    {
        // Check if the answer is true
        if (answer.text == correctAnswer)
        {
            // Update the questions correct count
            questionsCorrect++;

            Debug.Log("Correct");

            // Set up correct UI anim here later
        }

        // IF ANYONE WANTS TO PUT ANIMATIONS, PUT THEM HERE

        // Call the next question
        Next();
    }

}
