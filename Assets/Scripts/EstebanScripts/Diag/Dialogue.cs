using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{

    public List<string> dialogueContent;
    public List<Answer> answer;
    public List<int> rightAnswer = new ();
    public float answerTimer;
    public int noAnswerPoints;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class Answer 
{
    public string answer;
 public int points;

}