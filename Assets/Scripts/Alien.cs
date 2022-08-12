using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        GameController.DestroyAliens += destroyAlien;
    }
    private void OnDisable()
    {
        GameController.DestroyAliens -= destroyAlien;
    }

    void destroyAlien()
    {
        Destroy(gameObject);
    }
}
