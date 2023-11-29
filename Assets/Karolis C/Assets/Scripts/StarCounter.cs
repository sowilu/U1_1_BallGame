using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarCounter : MonoBehaviour
{
    public static StarCounter Instance;

    public TextMeshProUGUI text;
    public int Stars { 

        get 
        {
            return stars;
        } 
        set
        {
            stars = value;
            text.text = stars + "";
        }
}

    private int stars = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
