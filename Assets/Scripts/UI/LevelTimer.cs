using System;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    private float timer;
    
    [SerializeField] TMPro.TMP_Text timerText;

    private void Update()
    {
        timer = timer + Time.deltaTime; 
        timerText.text = timer.ToString("0000");
    }
}
