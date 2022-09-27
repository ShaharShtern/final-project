using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TagChange());
    }

    IEnumerator TagChange()
    {
        yield return new WaitForSeconds(0.5f);
        transform.gameObject.tag = "obstacle";
    }
}
