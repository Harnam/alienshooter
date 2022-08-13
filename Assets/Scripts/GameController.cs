using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject startscreen, restartscreen, gamescreen;

    [SerializeField]
    private GameObject platformPrefab, playerPrefab, portalPrefab;

    private GameObject platforms, player, portal = null;

    public delegate void destroyAlien();
    public static destroyAlien DestroyAliens;

    [HideInInspector]
    public static int score = 0;

    [SerializeField]
    private TextMeshProUGUI gameScore, endScore, highScore;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("highscore"))
            PlayerPrefs.SetInt("highscore", 0);
        highScore.text = PlayerPrefs.GetInt("highscore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            gameScore.text = score.ToString();
            if (!player.GetComponent<Player>().isAlive)
                playerDie();
        }
    }

    public void startGame()
    {
        //Debug.Log("Start Game");
        startscreen.SetActive(false);
        instGO();
        gamescreen.SetActive(true);
    }

    void instGO()
    {
        platforms = Instantiate(platformPrefab);
        player = Instantiate(playerPrefab);
        portal = Instantiate(portalPrefab);
    }

    public void playerDie()
    {
        Destroy(platforms);
        Destroy(player);
        Destroy(portal);
        DestroyAliens?.Invoke();
        endScore.text = score.ToString();
        if (score > PlayerPrefs.GetInt("highscore"))
            PlayerPrefs.SetInt("highscore", score);
        gamescreen.SetActive(false);
        restartscreen.SetActive(true);
    }

    public void restartGame()
    {
        //Debug.Log("reStart Game");
        restartscreen.SetActive(false);
        gamescreen.SetActive(true);
        instGO();
    }

    public void goMainMenu()
    {
        highScore.text = PlayerPrefs.GetInt("highscore").ToString();
        restartscreen.SetActive(false);
        startscreen.SetActive(true);
    }
}
