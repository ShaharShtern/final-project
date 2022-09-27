using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    public int randomX;
    public int randomY;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = new Vector3(Random.Range(-randomX, randomX), Random.Range(-randomY, randomY));
    }
}
