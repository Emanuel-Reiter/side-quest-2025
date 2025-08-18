using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera _camera;
    public LayerMask interactionLayer;
    public float interactionRange = 3.0f;

    private PlayerKeys playerKeys;

    public AudioSource keySource;
    public AudioClip[] keySound;

    private PlayerDependencies _dependencies;
    private DialogueController _dialogueController;

    public GameObject interactionPopup;

    private void Start()
    {
        _dialogueController = GetComponent<DialogueController>();
        _dependencies = GetComponent<PlayerDependencies>();
        playerKeys = GetComponent<PlayerKeys>();
        _camera = Camera.main;
        interactionPopup.SetActive(false);
    }

    private void Update()
    {
        InteractionRaycast();
    }

    private void InteractionRaycast()
    {
        Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hit, interactionRange, interactionLayer);
        if (hit.collider == null)
        {
            interactionPopup.SetActive(false);
            return;
        }

        interactionPopup.SetActive(true);

        if (_dependencies.input.isInteractPressed)
        {
            if (hit.collider.gameObject.CompareTag("Key"))
            {
                Key key = hit.collider.gameObject.GetComponent<Key>();

                switch (key.key_ID)
                {
                    case 1: playerKeys.key_01 = true; _dialogueController.PlayDialogue(); break;
                    case 2: playerKeys.key_02 = true; break;
                    case 3: playerKeys.key_03 = true; break;
                    case 4: playerKeys.key_04 = true; break;
                    default: return;
                }

                PlayerKeySound();
                key.gameObject.SetActive(false);
            }
        }
       
    }

    public void PlayerKeySound()
    {
        int randomNumber = Random.Range(0, keySound.Length);

        keySource.clip = keySound[randomNumber];
        keySource.Play();
    }
}
