using UnityEngine;

public class GeneratorSound : MonoBehaviour
{
    public AudioSource generatorSource;
    public AudioClip sound_on;

    private void Start()
    {
        generatorSource = GetComponent<AudioSource>();
    }

    public void TurnOn()
    {
        generatorSource.clip = sound_on;
        generatorSource.Play();
    }
}
