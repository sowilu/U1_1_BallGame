using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReloader : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
