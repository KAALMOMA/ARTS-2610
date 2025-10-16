using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SliderArrowControl : MonoBehaviour
{
    [Header("Slider Reference")]
    public Slider targetSlider;

    [Header("Settings")]
    public float changeSpeed = 0.5f;
    public bool holdToChange = true;

    void Update()
    {
        if (targetSlider == null)
            return;

        float valueChange = 0f;

        if (holdToChange)
        {
            if (Keyboard.current.digit0Key.isPressed)
                valueChange = changeSpeed * Time.deltaTime;
            else if (Keyboard.current.digit9Key.isPressed)
                valueChange = -changeSpeed * Time.deltaTime;
        }
        else
        {
            if (Keyboard.current.digit0Key.wasPressedThisFrame)
                valueChange = changeSpeed;
            else if (Keyboard.current.digit9Key.wasPressedThisFrame)
                valueChange = -changeSpeed;
        }

        if (Mathf.Abs(valueChange) > 0f)
        {
            targetSlider.value = Mathf.Clamp(
                targetSlider.value + valueChange,
                targetSlider.minValue,
                targetSlider.maxValue
            );
        }
    }
}
