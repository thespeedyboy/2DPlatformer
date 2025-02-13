using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveMovment : MonoBehaviour
{
    private Vector3 startPosition;
    private float xChange = 0;
    private float yChange = 0;
    private float zChange = 0;

    [Header("X Movement")]
    public bool isXMoving;
    public bool isXUsingSine;
    public float xAmp;    //How Far It Moves 
    public float xPeriod; //How Long IT Takes To Repeat
    [Header("Y Movement")]
    public bool isYMoving;
    public bool isYUsingSine;
    public float yAmp;    //How Far It Moves 
    public float yPeriod; //How Long IT Takes To Repeat
    [Header("Z Movement")]
    public bool isZMoving;
    public bool isZUsingSine;
    public float zAmp;    //How Far It Moves 
    public float zPeriod; //How Long IT Takes To Repeat
    void Start()
    {
        //Find starting position
        startPosition = transform.position;
    }
    void Update()
    {
        if(isXMoving)
        {
            xChange = WaveMove(xAmp, xPeriod, isXUsingSine);
        }
        if (isYMoving)
        {
            yChange = WaveMove(yAmp, yPeriod, isYUsingSine);
        }
        if (isZMoving)
        {
            zChange = WaveMove(zAmp, zPeriod, isZUsingSine);
        }


        //update position
        transform.position = new Vector3(startPosition.x + xChange, startPosition.y + yChange, startPosition.z + zChange);
    }
    //Wave Move Script
    public float WaveMove(float Amp, float period, bool isUsingSine)
    {
        if (period != 0)
        {
            if (isUsingSine)
            {
                return Amp * Mathf.Sin(Time.time * (6.28f / period));
            }
            else
            {
                return Amp * Mathf.Cos(Time.time * (6.28f / period));
            }
                    
        }
        else
        {
            return 0;
        }
    }
}
