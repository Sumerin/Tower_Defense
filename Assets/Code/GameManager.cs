using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private int _score;
    private int _money;
    private int _health;
    private Text score_text;
    private Text money_text;
    private Text health_text;

    #region singleton
    private static GameManager _instance;

    public static GameManager instance
    {
        get
        {
            if(_instance==null)
            {
                GameObject t = new GameObject("GameManager");
                t.AddComponent<GameManager>();
               
            }
            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        _instance = this;

        _score = 0;
        _money = 1000;
        _health = 100;
        money_text = GameObject.Find("Money").GetComponent<Text>();
        score_text = GameObject.Find("Score").GetComponent<Text>();
        health_text = GameObject.Find("Health").GetComponent<Text>();
        Print();
    }
#endregion

    
    #region Get_Set

    public int score
    {
        get
        {
            return _score;
        }
        set
        {
            if(value>0)
            {
                _score += value;
                Print();
            }
        }
    }

    public int money
    {
        get
        {
            return _money;
        }
        set
        {
            if (value > 0)
            {
                _money += value;
                Print();
            }
        }
    }
    public int health
    {
        get
        {
            return _health;
        }
        set
        {
            
                _health += value;
                Print();
            if(health<=0)
            {
                EndGame();
            }
        }
    }    
    #endregion


    

    private void Print()
    {
        score_text.text = "Score: " + _score;
        money_text.text = "Money: " + _money;
        health_text.text = "Health: " + _health;
    }

    private void EndGame()
    {
        Debug.Log("KONIEC GRY");
    }
}
