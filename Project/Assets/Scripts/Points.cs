using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Points : MonoBehaviour
{
    private int minutes;
    private int seconds;
    [SerializeField] float time;
    private int bestMinutes;
    private int bestSeconds;
    [SerializeField] float bestScore;
    [SerializeField] float distance;
    [SerializeField] Text textDistance;
    [SerializeField] Text textActualTime;
    [SerializeField] Text textBestTime;
    

    public void Start()
    {
        time = ChangeScene.time;
        minutes = Mathf.FloorToInt(time / 60);
        seconds = Mathf.FloorToInt(time % 60);
        textActualTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        bestScore = PlayerPrefs.GetFloat("highScore", float.MaxValue);
        bestMinutes = Mathf.FloorToInt(bestScore / 60);
        bestSeconds = Mathf.FloorToInt(bestScore % 60);
        textBestTime.text =string.Format("{0:00}:{1:00}", bestMinutes, bestSeconds);

        distance = ChangeScene.distanceTraveled;
        textDistance.text = distance.ToString();

        checkTimes();
    }

    private void checkTimes() {
        Debug.Log($"Comprobando tiempos: Actual {time}, Mejor {bestScore}");
        if (bestScore > time)
        {
            bestScore = time;
            PlayerPrefs.SetFloat("highScore", bestScore);
            PlayerPrefs.Save();
            Debug.Log($"Nuevo mejor tiempo guardado: {bestScore}");


            bestMinutes = Mathf.FloorToInt(bestScore / 60);
            bestSeconds = Mathf.FloorToInt(bestScore % 60);
            textBestTime.text =string.Format("{0:00}:{1:00}", bestMinutes, bestSeconds);
        }
    }
}