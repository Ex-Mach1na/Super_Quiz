using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private Text questionText;
    [SerializeField] private List<Button> optionButton;
    [SerializeField] private List<Sprite> optionButtonIcon;
    [SerializeField] private List<Image> optionIcon;
    [SerializeField] private Sprite correct, wrong;
    public Text ScoreText;
    public Text TimerText;
    public float Timeout = 5f;


    private int score;
    private float questionTime;


    // Start is called before the first frame update
    public void setQuestionInUi(Quiz ques)
    {
        questionText.text = ques.Question;
        for(int i=0; i<3; i++)
        {
            Text option = optionButton[i].GetComponentInChildren<Text>();
            option.text = ques.Options[i];

            optionIcon[i].sprite = optionButtonIcon[i];

        }
        ScoreText.text = score.ToString();
        questionTime = Time.time;
    }

    public void setIcon(int buttonIndex, bool isCorrect)
    {

        if (isCorrect)
        {
            optionIcon[buttonIndex].sprite = correct;
        }
        else
        {
            optionIcon[buttonIndex].sprite = wrong;
        }
    }


    public float getQuestionSetTime()
    {
        return questionTime;
    }
    


    public void setScore(int scoreT)
    {
        score = scoreT;
    }

    public void setTime(float T)
    {
        TimerText.text = T.ToString();
    }

    private void Start()
    {
        score = 0;
        setScore(score);
    }

    
}
