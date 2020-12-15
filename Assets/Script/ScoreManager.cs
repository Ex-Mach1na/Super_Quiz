using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class ScoreManager : MonoBehaviour
{
    public ScrollRect _scrollrect;
    public GameObject text;
    public GameObject MainMenu;
    public static ScoreManager instance;

    private ScoreData sdata = new ScoreData();
    private ScoreDataList sdatalist = new ScoreDataList();
    

    private GameObject sText;

    private void Awake()
    {
        instance = this;
        loadData();
        
    }

    public void loadData()
    {
        if (!File.Exists(Application.dataPath + "/dataset.json"))
        {

            Debug.Log("No settings file found, creating new one.");


            sdatalist = new ScoreDataList();
            string jsonExport = JsonUtility.ToJson(sdatalist);
            File.WriteAllText(Application.dataPath + "/dataset.json", jsonExport);

        }
        else
        {

            Debug.Log("Settings file found, loading settings.");

            string jsonImport = File.ReadAllText(Application.dataPath + "/dataset.json");
            sdatalist = JsonUtility.FromJson<ScoreDataList>(jsonImport);

            foreach (ScoreData scoredata in sdatalist.scoredatalist)
            {
                updateDatainUI(scoredata);
            }

        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    public void saveNow(int score)
    {
        sdata.time = System.DateTime.Now.ToString();
        //sdata.time = "sometime";
        sdata.score = score;
        sdatalist.scoredatalist.Add(sdata);
        updateDatainUI(sdata);

        Debug.Log(sdata.time + "     " + sdata.score);
        

        save();

    }

    public void save()
    {
        string jsonExport = JsonUtility.ToJson(sdatalist);
        File.WriteAllText(Application.dataPath + "/dataset.json", jsonExport);
    }

    void updateDatainUI(ScoreData score)
    {
        sText = Instantiate(text, Vector2.zero, Quaternion.identity);
        sText.transform.SetParent(_scrollrect.content, false);
        Text T = sText.GetComponent<Text>();
        T.text = score.time + "        " + score.score;

        Debug.Log("Updated in UI = " + T.text);
    }

    public ScoreData getHighScore()
    {
        int maxScore = 0, midx = -1;
        for(int i=0; i<sdatalist.scoredatalist.Count; i++)
        {
            if (sdatalist.scoredatalist[i].score >= maxScore)
            {
                maxScore = sdatalist.scoredatalist[i].score;
                midx = i;
            }
        }
        return sdatalist.scoredatalist[midx];
    }

    void close()
    {
        this.gameObject.SetActive(false);
        MainMenu.SetActive(true);
    }

    // Update is called once per frame
}
