using UnityEngine;
using System.Collections.Generic;

public class LampsController : MonoBehaviour
{
    private List<Lamp> levelLamps = new List<Lamp>();
    private GameObject[] lampsGameObjects;

    private bool lampsToggle = false;

    private void Awake()
    {
        FindAndRegisterAllLamps();
    }

    void Start()
    {
        //ToggleAllLamps(lampsToggle);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) ToggleAllLamps(lampsToggle);
    }

    public void ToggleAllLamps(bool toggle)
    {
        foreach (Lamp lamp in levelLamps)
        {
            if (lamp == null || lamp.Equals(null)) continue;
            lamp.ToggleLight(lampsToggle);
        }
        lampsToggle = !lampsToggle;
    }

    public void FindAndRegisterAllLamps()
    {
        levelLamps.Clear();
        lampsGameObjects = GameObject.FindGameObjectsWithTag("Lamp");

        foreach (GameObject go in lampsGameObjects)
        {
            Lamp lampComponent = go.GetComponent<Lamp>();
            if (lampComponent == null) continue;
            else levelLamps.Add(lampComponent);
        }
    }
}
