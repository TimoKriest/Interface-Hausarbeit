using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public List<QestionsAndAnswers> QestionsAndAnswersList;
    public GameObject[] options;
    public int currentQuestion;
    public TMP_Text QuestonText;

    private void Start()
    {
        SetQuestion();
    }

    public void correctAnswer(){
        QestionsAndAnswersList.RemoveAt(currentQuestion);
        SetQuestion();
    }

    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            // Alle Fragen werden beim Start auf falsch gesetzt.
            options[i].GetComponent<AnswerScipt>().isCorrect = false;
            options[i].GetComponentInChildren<TMP_Text>().text = QestionsAndAnswersList[currentQuestion].Answers[i];

            if (QestionsAndAnswersList[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScipt>().isCorrect = true;
            }
        }
    }

    void SetQuestion()
    {
       currentQuestion = Random.Range(0, QestionsAndAnswersList.Count);
        QuestonText.text = QestionsAndAnswersList[currentQuestion].Questions;
        SetAnswer();
    }


}
