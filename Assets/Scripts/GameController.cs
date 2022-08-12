using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject startscreen;

    [SerializeField]
    private GameObject platformPrefab, playerPrefab;

    private GameObject platforms, player = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        Debug.Log("Start Game");
        startscreen.SetActive(false);
        platforms = Instantiate(platformPrefab);
        player = Instantiate(playerPrefab);
    }

    public void restartGame()
    {

    }
}
