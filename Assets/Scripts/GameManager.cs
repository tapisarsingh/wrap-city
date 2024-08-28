using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject player;
    public GameObject startPanel;
    public GameObject inGame;
    public GameObject restartPanel;
    public bool gameStart;
    public bool playerDead;
    public int distance;
    public TextMeshProUGUI coins;
    public TextMeshProUGUI maxDistance;
    public static int collectedCoins;
    public GameObject[] hearts;
    public int heartCounter;
    public Transform lastCheckPoint;
    public void Start()
    {
        if (PlayerPrefs.GetInt("start") == 1)
        {
            StartGame();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartGame();
            PlayerPrefs.SetInt("start", 1);
        }

        if (player.transform.position.y < -6)
        {
            playerDead = true;
        }
    }
    public void CoinCollect()
    {
        collectedCoins++;
        coins.text = collectedCoins.ToString();
    }
    private void StartGame()
    {
        if (!gameStart)
        {
            player.SetActive(true);
            inGame.SetActive(true);
            startPanel.SetActive(false);
            gameStart = true;
        }
    }



    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public int GetDistance()
    {
        return PlayerPrefs.GetInt("distance");

    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("start", 0);
    }

    public void ReSapwn()
    {
        hearts[heartCounter].SetActive(false);
        heartCounter++;
        player.SetActive(false);
        player.transform.position = lastCheckPoint.position;
        player.SetActive(true);
    }
}
