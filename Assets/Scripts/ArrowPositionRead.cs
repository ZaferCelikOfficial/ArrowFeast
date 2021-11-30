using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArrowPositionRead : MonoBehaviour
{
    OperatorEnum MathOperations;
    public static Vector3 ArrowPosition;
    public static int ArrowNumber=1;
    public TMP_Text HealthText;
    private void Start()
    {
        HealthText.text = "1";
    }
    void Update()
    {
        ArrowPosition = this.transform.position;
    }
    public static void UpdateNumberofArrows(OperatorEnum symbol, int number)
    {
        Debug.Log(symbol);
        switch (symbol)
        {
            case OperatorEnum.summation:
                ArrowNumber += number;
                break;
            case OperatorEnum.subtraction:
                ArrowNumber -= number;
                break;
            case OperatorEnum.multiplication:
                ArrowNumber *= number;
                break;
            case OperatorEnum.division:
                ArrowNumber /= number;
                break;
        }
        Debug.Log(ArrowNumber);
        if (ArrowNumber<=0)
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
}
