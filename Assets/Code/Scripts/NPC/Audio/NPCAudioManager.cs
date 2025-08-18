using System.Threading;
using UnityEngine;

public class NPCAudioManager : MonoBehaviour
{
    public AudioSource roarSource;
    public AudioSource footstepsSource;

    public AudioClip[] roars;

    public AudioClip[] footsteps;

    public bool isRoarActive = true;
    float roarTimer = 1.0f;

    private void Update()
    {
        if(isRoarActive)
        {
            if (roarTimer <= 0.0f)
            {
                PlayerRoarSound();
                roarTimer = Random.Range(3.0f, 6.0f);
            }

            roarTimer -= Time.deltaTime;
        }   
    }

    public void PlayerRoarSound()
    {
        int randomNumber = Random.Range(0, roars.Length);

        roarSource.clip = roars[randomNumber];
        roarSource.Play();

    }

    public void PlayerFootstepsSound() { 
        int randomNumber = Random.Range(0, footsteps.Length);

        footstepsSource.clip = footsteps[randomNumber];
        footstepsSource.Play();
    }
}
