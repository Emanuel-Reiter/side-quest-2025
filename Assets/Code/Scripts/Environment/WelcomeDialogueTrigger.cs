using UnityEngine;

public class WelcomeDialogueTrigger : MonoBehaviour
{
    public DialogueController dialogueController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueController.PlayDialogue(0);
            this.gameObject.SetActive(false);
        }
    }
}
