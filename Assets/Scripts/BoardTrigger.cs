
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoardTrigger : MonoBehaviour
{
    public OperatorEnum MathOperations;
    public TMP_Text MathText;
    public int number;
    private string MathOperator;
    // Start is called before the first frame update
    void Start()
    {
        switch (MathOperations)
        {
            case OperatorEnum.summation:
                MathOperator = "+";
                break;
            case OperatorEnum.subtraction:
                MathOperator = "-";
                break;
            case OperatorEnum.division:
                MathOperator = "/";
                break;
            case OperatorEnum.multiplication:
                MathOperator = "x";
                break;
        }
        UpdateTextBoxes();
    }
    void UpdateTextBoxes()
    {
        MathText.text = MathOperator + number;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (!GameManager.isGameStarted || GameManager.isGameEnded)
        {
            return;
        }
        ArrowPositionRead.instance.UpdateNumberofArrows(MathOperations, number);
        this.transform.parent.gameObject.SetActive(false);
    }
}

