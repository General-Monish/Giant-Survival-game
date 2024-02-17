using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float minspeed;
    public float maxspeed;
    float speed;


    player playerScript;
    public int damage;
    public GameObject explosions;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minspeed, maxspeed);
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D hitObject)
    {
        if (hitObject.tag == "Player")
        {
            playerScript.TakeDamage(damage);
            Instantiate(explosions, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (hitObject.tag == "ground")
        {
            Instantiate(explosions, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
