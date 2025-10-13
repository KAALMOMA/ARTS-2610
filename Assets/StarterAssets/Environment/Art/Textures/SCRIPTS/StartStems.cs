using UnityEngine;

public class StartStems : MonoBehaviour
{
    public AudioSource[] sources;
    void Start()
        {

            double startTime = AudioSettings.dspTime + 0.5; // start in 0.5 seconds

            foreach (AudioSource src in sources)
            {
                src.PlayScheduled(startTime);
            }
        }
}
