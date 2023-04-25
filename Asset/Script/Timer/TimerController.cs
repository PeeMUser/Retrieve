using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public TimerController instance;
    public TimerController s;
    public Text timeCounter;

    private TimeSpan timePlaying;
    private bool timerGoing;
    private float elapsedTime;

    private void Awake()
    {
        s = GetComponent<TimerController>();
        timeCounter = GetComponent<Text>();
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        timeCounter.text = "Time: 00:00.00";
        timerGoing = false;
    }
    private void Update()
    {
        BeginTimer();
    }
    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0;
   StartCoroutine(UpdateTimer());
    }
    public void EndTimer()
    {
        timerGoing = false;
    }
    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.fixedDeltaTime;
            
            timePlaying = TimeSpan.FromSeconds(elapsedTime);

            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;
           
            yield return null;
        }
    }
    public void StartTimer()
    {

    }
}
