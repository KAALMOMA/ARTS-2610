using UnityEngine;

public class ColorPulse : MonoBehaviour
{
    public double intervalSeconds = 0.495867; // Since my stems are all at 121bpm, the time difference between each 1/4 note is approx. 496ms.
    private double nextEventTime;

    public Material mat1;
    public Material mat2;

    public Renderer otherRenderer;

    public bool isMat1 = false;
    

    void Start()
    {
        nextEventTime = AudioSettings.dspTime + intervalSeconds;
    }

    void Update()
    {
        double dspTime = AudioSettings.dspTime;
        Renderer objectRenderer = GetComponent<Renderer>();

        if (dspTime >= nextEventTime)
        {
            ChangeMat(objectRenderer,otherRenderer);

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
