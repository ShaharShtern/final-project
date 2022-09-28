using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LostScript : MonoBehaviour
{
    public Button retry;

    public void OnRetry()
    {
        SceneManager.LoadScene("GameScene");
    }
}
