using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFinishingSequence : MonoBehaviour
{ 
   public float EndGameForce = -6250f;
    float EndForce;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            Rigidbody rigidBody = other.gameObject.GetComponent<Rigidbody>();
            if (rigidBody.velocity.z <= 0) { ArrowMover.Speed = 0; OnFinish(); }
            ArrowMover.Speed = rigidBody.velocity.z;
            Debug.Log("ApplyingForce" + rigidBody.velocity.z);
        }
        if (other.gameObject.tag=="Player")
        {
            if (other.GetComponent<Rigidbody>() == null) 
            {
                other.gameObject.AddComponent<Rigidbody>();
                Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
                rb.useGravity = false;
                this.gameObject.SetActive(false);
                rb.velocity=new Vector3(0,0,ArrowMover.Speed) ;
                Debug.Log("First Touch on Finish Spot " + rb.velocity.z);
            }
            else
            {
                Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
                if (ArrowPositionRead.ArrowNumber > 500) { EndForce = -125; rb.AddForce(new Vector3(0, 0, EndForce), ForceMode.Force);  }
                else { EndForce = EndGameForce / ArrowPositionRead.ArrowNumber; rb.AddForce(new Vector3(0, 0, EndForce), ForceMode.Force); }

                //this.gameObject.SetActive(false);
            }
            
        }
        

    }
    public void OnFinish()
    {
        GameManager.instance.EndGame();
        //GameManager.instance.OnLevelCompleted();
    }
}
