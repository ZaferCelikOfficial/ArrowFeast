using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierTrigger : MonoBehaviour
{
    Animator SoldierAnimator;
    AudioSource CrashAudioSource;
    [SerializeField] AudioClip Crashing;
    private void Start()
    {
        CrashAudioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            SoldierAnimator = this.GetComponent<Animator>();
            SoldierAnimator.SetBool("isFalling", true);
            CrashAudioSource.PlayOneShot(Crashing);
            if(this.gameObject.tag=="PlaygroundGuardian")
            {
                for (int i = 0; i < 5; i++)
                {
                    ArrowPooler.instance.AddArrowToPool();
                    ArrowPositionRead.instance.UpdateHealthBoxes();
                }
                if(ArrowPositionRead.instance.ArrowNumber<=0)
                {
                    Failed();
                }
            }
        }
    }
    public static void Failed()
    {
        GameManager.instance.EndGame();
        GameManager.instance.OnLevelFailed();
    }
}
