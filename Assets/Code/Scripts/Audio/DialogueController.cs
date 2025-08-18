using System;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public AudioSource dialogueSource;

    public AudioClip welcome_audio;
    public AudioClip powerOff_audio;
    public AudioClip securityGuard_audio;
    public AudioClip powerOn_audio;


    public GameObject enemy_01;
    private LampsController lampsController;
    public AudioSource musicSource;

    private PlayerKeys playerKeys;

    public Collider[] generatorColliders;
    public GameObject generatorText;

    private bool isDialogueTimer = false;
    private float dialogueTimer_03 = 19.0f;
    private void Start()
    {
        lampsController = GetComponent<LampsController>();
        playerKeys = GetComponent<PlayerKeys>();
        enemy_01.SetActive(false);

        foreach (var collider in generatorColliders)
        {
            collider.enabled = false;
        }

        generatorText.SetActive(false);
    }

    private void Update()
    {
        if (playerKeys.generatorsOn == 3) PlayDialogue(3);
        if (isDialogueTimer) dialogueTimer_03 -= Time.deltaTime;
        if (isDialogueTimer && dialogueTimer_03 < 0.0f) PlayDialogue(2);
    }

    public void PlayDialogue(int index)
    {
        switch (index)
        {
            case 0:
                dialogueSource.clip = welcome_audio;
                break;

            case 1:
                dialogueSource.clip = powerOff_audio;
                enemy_01.SetActive(true);
                lampsController.ToggleAllLamps(false);

                foreach (var collider in generatorColliders)
                {
                    collider.enabled = true;
                }

                generatorText.SetActive(true);
                isDialogueTimer = true;
                musicSource.Play();
                break;

            case 2:
                dialogueSource.clip = securityGuard_audio;
                isDialogueTimer = false;
                break;

            case 3:
                dialogueSource.clip = powerOn_audio;
                break;

            default:
                dialogueSource.clip = powerOn_audio;
                break;

        }
        dialogueSource.Play();
    }
}
