using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    public Transform[] targetObjects;
    public Light[] pointLights;

    public float Distance { get; private set; } // Minimum distance
    public Transform ClosestTarget { get; private set; } // Target with minimum distance

    void Update()
    {
        if (targetObjects == null || targetObjects.Length == 0)
        {
            Distance = 0f;
            ClosestTarget = null;
            return;
        }

        float minDistance = float.MaxValue;
        Transform closest = null;

        foreach (Transform target in targetObjects)
        {
            if (target == null) continue;
            float currentDistance = Vector3.Distance(transform.position, target.position);
            if (currentDistance < minDistance)
            {
                minDistance = currentDistance;
                closest = target;
            }
        }

        Distance = minDistance;
        ClosestTarget = closest;


        if (pointLights != null)
        {
            foreach (Light light in pointLights)
            {
                if (light == null) continue;
                light.intensity = Mathf.Clamp(5f - Distance, 0f, 5f) * 10;
            }
        }

    }
}
