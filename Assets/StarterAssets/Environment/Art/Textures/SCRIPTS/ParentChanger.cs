using UnityEngine;

public class ParentChanger : MonoBehaviour
{
    public Transform childObject; 
    public Transform newParent;   
    public DistanceChecker distanceChecker;

    public AudioSource playerBoundSource;
    public AudioClip clip;

    public float volume;


    void Update()
    {
        float d = distanceChecker.Distance;
        Transform closest = distanceChecker.ClosestTarget;
        if(d < 0.9 && d != 0 && closest == childObject)
        {
            childObject.SetParent(newParent, false);
            childObject.transform.localPosition = new Vector3(0f, 6f, 0f);
            playerBoundSource.PlayOneShot(clip, volume);
        }   
    }
}