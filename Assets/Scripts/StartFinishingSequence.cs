using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartFinishingSequence : MonoBehaviour
{
    public float EndGameForce = -35714f;
    float EndForce;
    public static bool isMovingAvailable;
    Animator SoldierAnimator;
    public TMP_Text MultiplicationText;
    public int MultiplicationNumber;
    
   
    private void Start()
    {
        if(this.gameObject.tag!="Finish")
        { MultiplicationText.text = "x" + MultiplicationNumber; }
        isMovingAvailable = true;
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (!GameManager.isGameStarted || GameManager.isGameEnded)
        {
            CheckifMovingForward(other);
            return;
        }
        if (other.gameObject.tag == "Player")
        {
            if (other.GetComponent<Rigidbody>() == null)
            {
                other.gameObject.AddComponent<Rigidbody>();
                Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
                rb.useGravity = false;
                this.gameObject.SetActive(false);
                rb.velocity = new Vector3(0, 0, ArrowMover.Speed);
                Debug.Log("First Touch on Finish Spot " + rb.velocity.z);
                isMovingAvailable = false;
                
            }
            else
            {
                Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
                if (ArrowPositionRead.instance.ArrowNumber > 500) { EndForce = -71.43f; rb.AddForce(new Vector3(0, 0, EndForce), ForceMode.Force);  }
                else { EndForce = (EndGameForce) / ArrowPositionRead.instance.ArrowNumber; rb.AddForce(new Vector3(0, 0, EndForce), ForceMode.Force);  }
                CheckifMovingForward(other);
                ArrowMover.Speed = rb.velocity.z;
                Debug.Log("ApplyingForce" + rb.velocity.z+ " Arrow Counted "+ArrowPositionRead.instance.ArrowNumber);
                
            }
        }
    }
    void CheckifMovingForward(Collider other)
    {
        if(other.GetComponent<Rigidbody>() != null)
        {
            
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb.velocity.z <= 0.8f)
            {
                ArrowMover.Speed = 0;
                rb.velocity = new Vector3(0, 0, 0);
                rb.drag = 10;
                OnFinish();
                ArrowPositionRead.instance.SuccessSound();
            }
        }
    }
    public void OnFinish()
    {
        
        GameManager.instance.PointCounter(ArrowPositionRead.instance.ArrowNumber*MultiplicationNumber);
        GameManager.instance.EndGame();
        GameManager.instance.OnLevelCompleted();
        
    }
}
