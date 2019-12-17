using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioAnalyser : MonoBehaviour
{
    AudioSource a;
    public bool useMic = false;
    public AudioClip clip; 
    public AudioMixerGroup amgMaster;

    public int frameSize = 512;
    public static float[] bands;
    public static float[] spectrum;

    public float binWidth;
    public float sampleRate;

    private void Awake()
    {
        a = GetComponent<AudioSource>();
        spectrum = new float[frameSize];
        bands = new float[(int)Mathf.Log(frameSize, 2)];

        //play audio
        a.clip = clip;
        a.outputAudioMixerGroup = amgMaster;
        a.Play();
    }

    void GetFrequencyBands()
    {
        for (int i = 0; i < bands.Length; i++)
        {
            int start = (int)Mathf.Pow(2, i) - 1;
            int width = (int)Mathf.Pow(2, i);
            int end = start + width;
            float average = 0;
            for (int j = start; j < end; j++)
            {
                average += spectrum[j] * (j + 1);
            }
            average /= (float)width;
            bands[i] = average;
            //Debug.Log(i + "\t" + start + "\t" + end + "\t" + start * binWidth + "\t" + (end * binWidth));
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        sampleRate = AudioSettings.outputSampleRate;
        binWidth = AudioSettings.outputSampleRate / 2 / frameSize;
    }

    // Update is called once per frame
    void Update()
    {
        a.GetSpectrumData(spectrum, 0, FFTWindow.Blackman);
        GetFrequencyBands();
    }
}
