using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPerSecondTimer : MonoBehaviour
{
    public float TimerDuration = 1f;

    public double CatPerSecond { get; set; }

    private float counter;

    private void Update()
    {
        counter += Time.deltaTime;

        if (counter >= TimerDuration)
        {
            CatManger.instance.SimpleCatIncrease(CatPerSecond);

            counter = 0;
        }
    }
}
