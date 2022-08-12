using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject startscreen, restartscreen;

    [SerializeField]
    private GameObject platformPrefab, playerPrefab, portalPrefab;

    private GameObject platforms, player, portal = null;

    public delegate void destroyAlien();
    public static destroyAlien DestroyAliens;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
            if (!player.GetComponent<Player>().isAlive)
                playerDie();
    }

    public void startGame()
    {
        Debug.Log("Start Game");
        startscreen.SetActive(false);
        instGO();
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
        restartscreen.SetActive(true);
    }

    public void restartGame()
    {
        Debug.Log("reStart Game");
        restartscreen.SetActive(false);
        instGO();
    }

    public void goMainMenu()
    {
        restartscreen.SetActive(false);
        startscreen.SetActive(true);
    }
}
