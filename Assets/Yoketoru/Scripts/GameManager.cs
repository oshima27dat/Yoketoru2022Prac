#define DEBUG_KEY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    TextMeshProUGUI scoreText = default;

    static int ScoreMax => 99999;

    static int score;
    static float time;
    static float StartTime => 10;
    static bool clear;
    static bool gameover;

    private void Awake()
    {
        Instance = this;
        ClearScore();
        Item.ClearCount();
        time = StartTime;
        clear = false;
        gameover = false;

    }
    // Start is called before the first frame update
    void Start()
    {
        TinyAudio.PlaySE(TinyAudio.SE.Start);
    }

    // Update is called once per frame
    void Update()
    {
#if DEBUG_KEY
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene("Gameover", LoadSceneMode.Additive);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("Clear", LoadSceneMode.Additive);
        }
        else if(Input.GetKeyDown(KeyCode.P))
        {
            AddPoint(12345);
            
        }
#endif
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = $"{score:00000}";
        }
    }

    public static void AddPoint(int add)
    {
        score += add;

        //ãŒÀƒ`ƒFƒbƒN‚»‚Ì‚P Žè‘±‚«Œ^‚Ì“TŒ^
        //if(score > ScoreMax)
        //{
        //   score = ScoreMax;
        //}

        //ãŒÀƒ`ƒFƒbƒN‚»‚Ì‚Q Žè‘±‚«Œ^‚ÌÈ—ªŒ`
        //score = score > ScoreMax ? ScoreMax : score;

        //ãŒÀƒ`ƒFƒbƒN‚»‚Ì‚R ŠÖ”Œ^‚Å‹ß‘ã“I
        score = Mathf.Min(score, ScoreMax);

        if(score > ScoreMax)
        {
            score = ScoreMax;
        }
        if (Instance != null)
        {
            Instance.UpdateScoreText();
        }
    }


    public static void ClearScore()
    {
        score = 0;
        Instance.UpdateScoreText();
    }

    public static void ToClear()
    {
        if (clear || gameover) return;

        clear = true;
        SceneManager.LoadScene("Clear", LoadSceneMode.Additive);
        Time.timeScale = 0;
    }

    public static void ToGameover()
    {
        if (clear || gameover) return;

        gameover = true;
        SceneManager.LoadScene("Gameover", LoadSceneMode.Additive);
        Time.timeScale = 0;
    }

 }
