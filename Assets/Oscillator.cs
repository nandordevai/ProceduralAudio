using System.Collections;
using System.Collections.Generic;
using System; 
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    public float gain;

    double frequency;
    double[] frequencies;
    double increment;
    double phase;
    double sampleRate = 48000.0;
    bool isPlaying = false;
    double cycleStart = 0;
    System.Random r;

    void Awake()
    {
        frequencies = new double[] { 440, 523.25, 587.33, 659.25, 783.99, 880 };
        r = new System.Random();
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        double cycle = AudioSettings.dspTime;
        if (cycle > cycleStart + 1) {
            cycleStart = cycle;
            isPlaying = true;
            int i = r.Next(frequencies.Length);
            frequency = frequencies[i];
        } else {
            if (cycle > cycleStart + 0.25) {
                isPlaying = false;
            }
        }
        if (!isPlaying) {
            return;
        }
        increment = frequency * 2.0 * Mathf.PI / sampleRate;
        for (int i = 0; i < data.Length; i += channels)
        {
            phase += increment;
            data[i] = (float) (gain * Envelope() * Mathf.Sin((float) phase));

            if (channels == 2)
            {
                data[i + 1] = data[i];
            }
        }
    }

    double Envelope()
    {
        return 1;
    }
}