using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public AudioSource dialogueSource;

    public AudioClip welcome_audio;
    public AudioClip powerOff_audio;
    public AudioClip securityGuard_audio;
    public AudioClip powerOn_audio;

    private int dialogueIndex = 0;

    public GameObject enemy_01;
    private LampsController lampsController;
    public AudioSource musicSource;


    private void Start()
    {
        lampsController = GetComponent<LampsController>();
        enemy_01.SetActive(false);
}

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)) { 
            PlayDialogue();
        }
    }

    public void PlayDialogue()
    {
        switch (dialogueIndex)
        {
            case 0:
                dialogueSource.clip = welcome_audio;
                break;

            case 1:
                dialogueSource.clip = powerOff_audio;
                enemy_01.SetActive(true);
                lampsController.ToggleAllLamps(false);
                musicSource.Play();
                break;

            case 2:
                dialogueSource.clip = securityGuard_audio;
                break;

            case 3:
                dialogueSource.clip = powerOn_audio;
                break;

            default:
                dialogueSource.clip = powerOn_audio;
                break;

        }
        dialogueSource.Play();
        dialogueIndex++;
    }
}
