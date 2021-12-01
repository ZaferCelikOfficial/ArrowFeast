using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArrowPositionRead : MonoBehaviour
{
    public static ArrowPositionRead instance;
    OperatorEnum MathOperations;
    public Vector3 ArrowPosition;
    public int ArrowNumber = 1;
    public TMP_Text HealthText;
    AudioSource SuccessAudioSource;
    [SerializeField] AudioClip Finished;
    private void Start()
    {
        if (instance == null)
            instance = this;

        SuccessAudioSource = GetComponent<AudioSource>();
        HealthText.text = "1";
    }
    void Update()
    {
        ArrowPosition = this.transform.position;
    }
    public void UpdateNumberofArrows(OperatorEnum symbol, int number)
    {
        Debug.Log(symbol);
        switch (symbol)
        {
            case OperatorEnum.summation:
                for (int i = 0; i < number; i++)
                {
                    ArrowPooler.instance.GetArrowFromPool();
                }
                //ArrowNumber += number;
                break;
            case OperatorEnum.subtraction:
                for (int i = 0; i < number; i++)
                {
                    ArrowPooler.instance.AddArrowToPool();
                }
                //ArrowNumber -= number;
                break;
            case OperatorEnum.multiplication:
                int sum = ArrowNumber * number;
                sum = sum - ArrowNumber;
                for (int i = 0; i < sum; i++)
                {
                    ArrowPooler.instance.GetArrowFromPool();
                }
                //ArrowNumber *= number;
                break;
            case OperatorEnum.division:
                int sum2 = ArrowNumber / number;
                sum2 = ArrowNumber - sum2;
                for (int i = 0; i < sum2; i++)
                {
                    ArrowPooler.instance.AddArrowToPool();
                }
                //ArrowNumber /= number;
                break;
        }
        Debug.Log(ArrowNumber);
        if (ArrowNumber <= 0)
        {
            Failed();
        }
    }

    public static void Failed()
    {
        GameManager.instance.EndGame();
        GameManager.instance.OnLevelFailed();
    }
    public void UpdateHealthBoxes()
    {
        string CountedArrow = ArrowNumber.ToString();
        HealthText.text = CountedArrow;
    }
    private void OnTriggerEnter(Collider other)
    {
        BoardTrigger OtherBoardTrigger = other.GetComponent<BoardTrigger>();
        if (OtherBoardTrigger == null) { return; }
        else { UpdateHealthBoxes(); }
    }
    public void SuccessSound()
    {
        SuccessAudioSource.PlayOneShot(Finished);
    }
}
