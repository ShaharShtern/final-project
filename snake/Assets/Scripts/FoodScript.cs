using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    public int randomX;
    public int randomY;
    public GameObject powerFruit;
    public int powerFruitCountdown=10;


    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (powerFruitCountdown>0&&CompareTag("power food")==false)
        {
            transform.position = new Vector3(Random.Range(-randomX, randomX), Random.Range(-randomY, randomY));
            powerFruitCountdown--;
        }

        if (powerFruitCountdown==0)
        {
            transform.position = new Vector3(Random.Range(-randomX, randomX), Random.Range(-randomY, randomY));
            Instantiate(powerFruit, new Vector3 (Random.Range(-randomX, randomX), Random.Range(-randomY, randomY), 0),Quaternion.identity);
            powerFruitCountdown = 10;
        }

        if (CompareTag("power food"))
        {
            GameObject.FindGameObjectWithTag("wall").SetActive(false);
            FindObjectOfType<SnakeScript>().scorePowerMultiplyer = 2;
            Destroy(gameObject);
        }
    }
}
