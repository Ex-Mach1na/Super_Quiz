using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public QuizManager qm;
    public ScoreManager scoreManager;

    public GameObject questionPanel;
    public GameObject gameOverPanel;
    public GameObject mainMenuPanel;
    public GameObject highScoreImage;
    public Text result;
    

    [SerializeField] public List<Quiz> MyQuiz = new List<Quiz>();

    
    private List<Quiz> Questions = new List<Quiz>();
    private int qIndex = 0;
    private int score = 0;
    private bool isAnswered = false, isGameEnd = true;
    

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }

    public void LoadQuestionOfCategory(int index)
    {
        questionPanel.gameObject.SetActive(true);
        for (int i=0; i<MyQuiz.Count; i++)
        {
            if(index == 9)
            {
                Questions.Add(MyQuiz[i]);
            }
            else
            {
                if ((int)MyQuiz[i].Category == index)
                {
                    Questions.Add(MyQuiz[i]);
                }
            }
        }

        qm.setQuestionInUi(Questions[qIndex]);
        isGameEnd = false;
    }

    public void GetAnswer(int index)
    {
        isAnswered = true;
        if( Questions[qIndex].correctAnsIndex == index)
        {
            qm.setIcon(index, true);
            score += 10;
            qm.setScore(score);
            Invoke("nextQuestion", 1.5f);
        }
        else
        {
            qm.setIcon(index, false);
            qm.setIcon(Questions[qIndex].correctAnsIndex, true);
            Invoke("gameOver", 1.5f);
        }
    }


    void nextQuestion()
    {
        if (qIndex < Questions.Count - 2)
        {
            qIndex++;
            qm.setQuestionInUi(Questions[qIndex]);
            isAnswered = false;
            
            
        }
        else
            gameOver();
    }


    public void gameOver()
    {
        highScoreImage.gameObject.SetActive(false);
        questionPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(true);
        result.text = score.ToString();
        isGameEnd = true;

        //Check for highscore
        ScoreData scoredata = scoreManager.getHighScore();
        if(scoredata.score<score)
        {
            highScoreImage.gameObject.SetActive(true);
        }

        scoreManager.saveNow(score);

    }

    public void reload()
    {
        scoreManager.save();
        gameOverPanel.gameObject.SetActive(false);
        
        mainMenuPanel.gameObject.SetActive(true);
        score = 0;
        qIndex = 0;
        qm.setScore(score);
    }

    private void Update()
    {
        if(!isAnswered && !isGameEnd)
        {
            float diff = Time.time - qm.getQuestionSetTime();
            qm.setTime(diff);
            if(diff >= qm.Timeout && !isGameEnd)
            {
                gameOver();
            }
        }
    }


}
