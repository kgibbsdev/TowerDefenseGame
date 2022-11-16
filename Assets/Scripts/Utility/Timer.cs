using UnityEngine;

public class Timer
{

    public float Frequency = 3.0f;
    public float CurrentTime = 0.0f;

    public delegate void TimerTick();
    public TimerTick Callback = null;

    public void Tick()
    {
        CurrentTime += Time.deltaTime;
        if (CurrentTime >= Frequency)
        {
            CurrentTime = 0.0f;
            Callback();
        }
    }
}
