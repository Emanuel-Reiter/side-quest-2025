using UnityEngine;
using UnityEngine.SceneManagement;

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
                    case 1: playerKeys.key_01 = true; _dialogueController.PlayDialogue(1); break;
                    case 2: playerKeys.key_02 = true; break;
                    case 3: playerKeys.key_03 = true; break;
                    case 4: playerKeys.key_04 = true; break;
                    default: return;
                }

                PlayerKeySound();
                key.gameObject.SetActive(false);
                return;
            }

            if (hit.collider.gameObject.CompareTag("Door"))
            {
                Door door = hit.collider.gameObject.GetComponent<Door>();

                if (playerKeys.key_01 && door.door_ID == 1) door.Open();
                if (playerKeys.key_02 && door.door_ID == 2) door.Open();
                if (playerKeys.key_03 && door.door_ID == 3) door.Open();
                if (playerKeys.key_04 && door.door_ID == 4) SceneManager.LoadScene("Level_01_Ending_Scene");

                hit.collider.gameObject.GetComponent<Collider>().enabled = true;
                return;
            }

            if (hit.collider.gameObject.CompareTag("Generator"))
            {
                playerKeys.TurnOnGenerator();
                Collider collider = hit.collider.gameObject.GetComponent<Collider>();
                GeneratorSound sound = hit.collider.gameObject.GetComponent<GeneratorSound>();
                sound.TurnOn();
                collider.enabled = false;
                return;
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
