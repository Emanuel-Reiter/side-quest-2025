using UnityEngine;

public class Lamp : MonoBehaviour
{
    private Light _light;

    private void Awake()
    {
        _light = GetComponentInChildren<Light>();
    }

    public void ToggleLight(bool toggle)
    {
        _light.enabled = toggle;
    }
}
