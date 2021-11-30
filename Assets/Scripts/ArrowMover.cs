using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMover : MonoBehaviour
{
    [Header("Movement Player")]
    [Range(0, 50)]
    public static float Speed = 10;
    Vector3 temp, temp2;
    GameObject objOffSet;
    float distanceFixer;
    [SerializeField] Vector2 MinMaxPlayerPos;

    [Header("Arrow Values")]

    [SerializeField] GameObject Arrow;
    CharacterController PlayerCharacterController;
    /// <summary>
    /// Its using for slicedobjectPoint
    /// </summary>


    /// <summary>
    /// Its using for 
    /// </summary>
    private void Start()
    {
        objOffSet = new GameObject();
        objOffSet.name = "OffsetObj";
        objOffSet.transform.position = this.transform.position;
        PlayerCharacterController = this.GetComponent<CharacterController>();
    }
    private void Update()
    {

        /*if (!GameManager.isGameStarted || GameManager.isGameEnded)
        {
            return;
        }*/
        MovePlayerForward();
        MoveCharacterLeftRight();
    }
    void MoveCharacterLeftRight()
    {
        if (Input.GetMouseButtonDown(0))
        {
            objOffSet.transform.position = new Vector3(CalculateX() * 3, 0, this.transform.position.z);
            temp = this.transform.position - objOffSet.transform.position;
            distanceFixer = Vector3.Distance(this.transform.position, objOffSet.transform.position);
        }
        if (Input.GetMouseButton(0))
        {
            objOffSet.transform.position = new Vector3(CalculateX() * 3, 0, this.transform.position.z);

            temp2 = objOffSet.transform.position + temp;
            temp2.y = this.transform.position.y;
            temp2.z = this.transform.position.z;
            temp2.x = Mathf.Clamp(temp2.x, MinMaxPlayerPos.x, MinMaxPlayerPos.y);

            this.transform.position = temp2;
            //transform.localRotation = Quaternion.Euler(new Vector3(0, Mathf.Clamp((CalculateX() + 2) * 30f, -45, 45), 0));
            if (distanceFixer - 01f > Vector3.Distance(this.transform.position, objOffSet.transform.position))
            {
                objOffSet.transform.localPosition = new Vector3(CalculateX() * 3, 0, this.transform.position.z);
                temp = this.transform.localPosition - objOffSet.transform.localPosition;
                distanceFixer = Vector3.Distance(this.transform.position, objOffSet.transform.localPosition);
            }
        }
        if (!Input.GetMouseButton(0))
        {
            objOffSet.transform.localPosition = new Vector3(CalculateX() * 3, 0, 0);
            temp = this.transform.localPosition - objOffSet.transform.localPosition;
            distanceFixer = Vector3.Distance(this.transform.position, objOffSet.transform.localPosition);
        }
    }
    float CalculateX()
    {
        Vector3 location = Input.mousePosition;
        return (location.x / (Screen.width / (MinMaxPlayerPos.y - MinMaxPlayerPos.x)) - MinMaxPlayerPos.y);
    }

    void MovePlayerForward()
    {
        PlayerCharacterController.Move(this.transform.forward * Speed * Time.deltaTime);
    }
}
