/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public List<GameObject> prefab;
        public int size;
    }
    public static ObjectPooler Instance;

    public List<Pool> pools;

    public Dictionary<string, Queue<GameObject>> poolDictionary;
    //public List<int> Distance = new List<int>;

    void Awake()
    {
        Instance = this;
    }
    /*public void PositionCreator()
    {
        Vector3 StartPosition = ArrowPositionRead.ArrowPosition;
        Distance.Add();
    } */  
   /* void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                for (int a = 0; a < pool.prefab.Count; a++)
                {
                    GameObject obj = Instantiate(pool.prefab[a]);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }
    public GameObject SpawnForGameObject(string tag, Vector3 position, Quaternion rotation)
    {
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }

    void Update()
    {

    }
}

  /*public class UnitControls:Component
{
    private Vector3 startPosition;
    public GameObject PooledObject;
    private List<Vector3> movePositionList = new List<Vector3>(,new float[10f,20f,30f,40f,50f],new int[5,10,20,30]);
    movePositionList =Vector3(ArrowPositionRead.ArrowPosition,{ 10f, 20f, 30f,40f },{ 5, 10, 20, 40});
    
    int positionIndex = 0;
    positionIndex = (positionIndex + 1) % movePositionList.Count;

    public List<Vector3> MovePositionList { get => movePositionList; set => movePositionList = value; }

    private List<Vector3> GetPositionListAround(Vector3 startPosition, float[] ringDistance, int[] ringPositionCount)
    {
        List<Vector3> positionList = new List<Vector3>();
        positionList.Add(startPosition);
        for (int ring = 0; ring < ringPositionCount.Length; ring++)
        {
            List<Vector3> ringPositionList = GetPositionListAround(startPosition, ringDistance[ring], ringPositionCount[ring]);
            positionList.AddRange(ringPositionList);
        }
        return positionList;
    }
    private List<Vector3> GetPositionListAround(Vector3 startPosition, float distance, int positionCount)
    {
        List<Vector3> positionList = new List<Vector3>();
        for (int i = 0; i < positionCount; i++)
        {
            int angle = i * (360 / positionCount);
            Vector3 dir = ApplyRotationToVector(new Vector3(0, 1, 0), angle);
            Vector3 position = startPosition + dir * distance;
            positionList.Add(position);
        }
        return positionList;
    }
    private Vector3 ApplyRotationToVector(Vector3 vec, float angle)
    {
        return Quaternion.Euler(0, 0, angle) * vec;
    }
}

    /*if (Input.GetMouseButtonDown(1)) {
            // Right mouse button down
            float3 targetPosition = UtilsClass.GetMouseWorldPosition();
    List<float3> movePositionList = GetPositionListAround(targetPosition, new float[] { 10f, 20f, 30f }, new int[] { 5, 10, 20 });
    int positionIndex = 0;
    Entities.WithAll<UnitSelected>().ForEach((Entity entity, ref MoveTo moveTo) => {
        moveTo.position = movePositionList[positionIndex];
        positionIndex = (positionIndex + 1) % movePositionList.Count;
        moveTo.move = true;
    });
        }
    private List<float3> GetPositionListAround(float3 startPosition, float[] ringDistance, int[] ringPositionCount)
    {
        List<float3> positionList = new List<float3>();
        positionList.Add(startPosition);
        for (int ring = 0; ring < ringPositionCount.Length; ring++)
        {
            List<float3> ringPositionList = GetPositionListAround(startPosition, ringDistance[ring], ringPositionCount[ring]);
            positionList.AddRange(ringPositionList);
        }
        return positionList;
    }
    private List<float3> GetPositionListAround(float3 startPosition, float distance, int positionCount)
    {
        List<float3> positionList = new List<float3>();
        for (int i = 0; i < positionCount; i++)
        {
            int angle = i * (360 / positionCount);
            float3 dir = ApplyRotationToVector(new float3(0, 1, 0), angle);
            float3 position = startPosition + dir * distance;
            positionList.Add(position);
        }
        return positionList;
    }
    private float3 ApplyRotationToVector(float3 vec, float angle)
    {
        return Quaternion.Euler(0, 0, angle) * vec;
    }*/

