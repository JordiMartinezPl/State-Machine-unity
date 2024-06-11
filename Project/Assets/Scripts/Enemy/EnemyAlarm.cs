using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlarm : MonoBehaviour
{
    SpriteRenderer alarmRenderer;

    public void playerDetected()
    {
        changeColor(Color.red);
    }

    public void playerLeft()
    {
        changeColor(new Color(0, 0, 0, 0));
    }

    private void changeColor(Color color)
    {
        if (alarmRenderer == null) alarmRenderer = GetComponent<SpriteRenderer>();

        alarmRenderer.color = color;
    }
}
