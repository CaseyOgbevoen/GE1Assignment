using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioAnalyser : MonoBehaviour
{
    AudioSource audioSource;

    public static int frameSize = 512;
    public static float[] samples = new float[512];
    public static float[] bands = new float[8];

    // Start is called before the first frame update
    void Start()
    {
            audioSource = GetComponent<AudioSource>();
    }

    //create frequency bands
    void GetFrequencyBands()
    {
        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2;
            }

            for (int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;

            }

            average /= count;
            bands[i] = average * 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
        GetFrequencyBands();
    }
}
