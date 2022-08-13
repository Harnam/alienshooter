using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject alienPrefab;

    [SerializeField]
    private float iniTime = 5f;

    private void Awake()
    {
        StartCoroutine(spawnAlien());
    }

    IEnumerator spawnAlien()
    {
        while (true)
        {
            GameObject alien = Instantiate(alienPrefab);
            alien.transform.position = transform.position;
            Debug.Log(iniTime / (1 + GameController.score * 0.1f));
            yield return new WaitForSeconds(iniTime / (1 + GameController.score * 0.1f));
        }
    }
}
