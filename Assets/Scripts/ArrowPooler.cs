using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ArrowObj
{
    [SerializeField] public GameObject Arrow;
}

/// <summary>
/// Arrow Pooler script is using for pooling arrow, get pool object or go back to pool 
/// </summary>
public class ArrowPooler : MonoBehaviour
{
    [SerializeField] List<ArrowObj> arrowPool = new List<ArrowObj>();
    [SerializeField] int ArrowPoolCount = 50;
    [SerializeField] GameObject ArrowPrefab;
    [SerializeField] GameObject ArrowListParent;
    [SerializeField] int RadiusArrowCount = 20;


    public static ArrowPooler instance;
    private void Start()
    {
        if (instance == null)
            instance = this;
        CreatePool();
    }
    void CreatePool()
    {
        float radIndex = .15f;
        ArrowObj a1 = new ArrowObj();
        var o1 = Instantiate(ArrowPrefab, ArrowListParent.transform);
        a1.Arrow = o1;
        a1.Arrow.transform.localPosition = Vector3.zero;
        arrowPool.Add(a1);

        for (int i = 0; i < RadiusArrowCount; i++)
        {

            for (int k = 0; k < ArrowPoolCount; k++)
            {
                var obj = Instantiate(ArrowPrefab, ArrowListParent.transform);
                ArrowObj arrowObj = new ArrowObj();
                arrowObj.Arrow = obj;
                arrowObj.Arrow.transform.localPosition = CalculatePosition(k * (360.0f / ArrowPoolCount), radIndex);
                arrowPool.Add(arrowObj);
                arrowObj.Arrow.SetActive(false);
            }
            radIndex += .15f;

        }


    }



    /// <summary>
    /// Calculating position of arrow using count to degree using radius to radius of circle
    /// </summary>
    /// <param name="count"></param>
    /// <param name="radius"></param>
    /// <returns></returns>
    Vector3 CalculatePosition(float count, float radius)
    {

        Vector3 pos = Vector3.zero;

        pos.x = Mathf.Cos(count * Mathf.PI / 180) * radius;

        pos.y = Mathf.Sin(count * Mathf.PI / 180) * radius;
        return pos;
    }


    public void GetArrowFromPool()
    {
        int lastIndex = lastIndexF();
        ArrowPositionRead.instance.ArrowNumber = lastIndex + 1;
        arrowPool[lastIndex].Arrow.SetActive(true);
    }

    int lastIndexF()
    {
        for (int i = 0; i < arrowPool.Count; i++)
        {
            if (arrowPool[i].Arrow.activeInHierarchy == false)
                return i;
        }
        return 0;
    }

    public void AddArrowToPool()
    {
        int lastIndex = lastIndexF();
        ArrowPositionRead.instance.ArrowNumber = lastIndex - 1;
        if (lastIndex != 0)
        {
            arrowPool[lastIndex - 1].Arrow.SetActive(false);
        }
        else
        {
            //Game failed
        }
    }
}
