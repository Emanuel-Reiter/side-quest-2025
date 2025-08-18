using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int door_ID;

    private bool isDoorOpen = false;
    private float doorTimer = 1.0f;

    private AudioSource doorSource;
    private Collider doorCollider;

    private void Start()
    {
        doorSource = GetComponent<AudioSource>();
        doorCollider = GetComponent<Collider>();
    }

    private void Update()
    {
        if (isDoorOpen && doorTimer > 0.0f)
        {
            doorTimer -= Time.deltaTime;
            this.transform.position = new Vector3(transform.position.x + (Time.deltaTime * 4.0f), transform.position.y, transform.position.z);
        }
    }

    public void Open()
    {
        isDoorOpen = true;
        doorSource.Play();
        StartCoroutine(DoorCorroutine());
    }

    private IEnumerator DoorCorroutine() {
        yield return new WaitForSeconds(1.0f);
        doorCollider.enabled = false;
    }
}
