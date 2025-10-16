using UnityEngine;

public class StartStems : MonoBehaviour
{
    public AudioSource[] sources;
    public double intervalSeconds = 0.49587; // Since my stems are all at 121bpm, the time difference between each 1/4 note is approx. 496ms.
    private double nextEventTime;
    public Material mat1;
    public Material mat2;

    public Renderer objectRenderer;
    public Renderer otherRenderer;
    public bool isMat1 = false;
    void Start()
    {

        double startTime = AudioSettings.dspTime + 0.5; // start in 0.5 seconds
        nextEventTime = startTime + intervalSeconds/2;

        foreach (AudioSource src in sources)
        {
            src.PlayScheduled(startTime);
        }
    }

    void Update()
    {
        double dspTime = AudioSettings.dspTime;

        if (dspTime >= nextEventTime)
        {
            ChangeMat(objectRenderer, otherRenderer);

            // Schedule the next event
            nextEventTime += intervalSeconds;
        }
    }
    void ChangeMat(Renderer or1, Renderer or2)
    {
        if (!isMat1)
        {
            or1.material = mat1;
            or2.material = mat2;
            isMat1 = true;
        }
        else
        {
            or1.material = mat2;
            or2.material = mat1;
            isMat1 = false;
        }
    }
}
