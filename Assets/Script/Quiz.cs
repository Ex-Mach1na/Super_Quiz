using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quiz
{
    public enum category
    {
        Geography,
        Bangladesh,
        Entertainment,
        History,
        Math,
        Science,
        Technology,
        GeneralKnowledge,
        Sports
    };

    public category Category;
    public string Question;
    public List<string> Options = new List<string>(4);
    public int correctAnsIndex;
}
