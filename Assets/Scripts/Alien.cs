using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{

    [SerializeField]
    private float speed = 5f;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, player.position.y), step);
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
