using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

// The code example shows how to implement a metronome that procedurally generates the audioSource sounds via the OnAudioFilterRead callback.
// While the game is paused or the suspended, this time will not be updated and sounds playing will be paused. Therefore developers of music scheduling routines do not have to do any rescheduling after the app is unpaused

[RequireComponent(typeof(AudioSource))]
public class Metronome : MonoBehaviour
{
    public double bpm = 140.0F;
    public float gain = 0.5F;
    public int signatureHi = 4;
    public int signatureLo = 4;
    private double nextTick = 0.0F;
    private float amp = 0.0F;
    private float phase = 0.0F;
    private double sampleRate = 0.0F;
    private int accent;
    private bool running = false;
    public float offset = 2f;
    [NotNull] public AudioSource audioSource;
    private Song song;

    public void Awake()
    {
        UnityThread.initUnityThread();
    }
    
    // this sets running to true which enables the OnAudioFilterRead loop
    public void Initialize(Song _song)
    {
        accent = signatureHi;
        var startTick = AudioSettings.dspTime;
        sampleRate = AudioSettings.outputSampleRate;
        nextTick = startTick * sampleRate;
        audioSource.enabled = true;
        song = _song;
        bpm = song.bpm * 4;
        offset = song.offset;
        running = true;
        
        Debug.Log("startTick: " + startTick);
        Debug.Log("sampleRate: " + sampleRate);
        Debug.Log("next tick: " + nextTick);
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        if (!running)
            return;

        var samplesPerTick = sampleRate * 60.0F / bpm * 4.0F / signatureLo;
        var sample = AudioSettings.dspTime * sampleRate;
        var dataLen = data.Length / channels;
        var n = 0;
        while (n < dataLen)
        {
            var x = gain * amp * Mathf.Sin(phase);
            var i = 0;
            while (i < channels)
            {
                data[n * channels + i] += x;
                i++;
            }

            //while (sample + n >= nextTick - sampleRate)
            //{
            //    song.NextNote();
            //}

            while (sample + n >= nextTick + offset * sampleRate)
            {
                song.NextNote();
                nextTick += samplesPerTick;
                amp = 1.0F;
                //if (++accent > signatureHi)
                //{
                //    accent = 1;
                //    amp *= 2.0F;
                //}
               // Debug.Log("Tick: " + accent + "/" + signatureHi);
            }
            phase += amp * 0.3F;
            amp *= 0.993F;
            n++;
        }
    }
}
