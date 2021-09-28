using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private GameObject spherePrefab;
    [SerializeField] private GameObject capsulePrefab;

    private GameObject _cube;
    private GameObject _sphere;
    private GameObject _capsule;

    private int _countCube;
    private int _countSphere;
    private int _countCapsule;

    public int minCount = 1;
    public int maxCount = 5;

    private int minPosition = -24;
    private int maxPosition = 24;

    public static Action<int, string> Generation = delegate { };

    void Start()
    {
        _countCube = UnityEngine.Random.Range(minCount, maxCount);
        _countSphere = UnityEngine.Random.Range(minCount, maxCount);
        _countCapsule = UnityEngine.Random.Range(minCount, maxCount);

        Generator(_countCube, cubePrefab, _cube);
        Generator(_countSphere, spherePrefab, _sphere);
        Generator(_countCapsule, capsulePrefab, _capsule);
    }

    void Generator(int count, GameObject objectPrefab, GameObject objectArray) 
    {
        for (int i = 0; i != count; i++) 
        {
            objectArray = Instantiate(objectPrefab) as GameObject;
            objectArray.transform.position = new Vector3(UnityEngine.Random.Range(minPosition, maxPosition), 0.5f, UnityEngine.Random.Range(minPosition, maxPosition));
        }

        Generation(count, objectPrefab.name);
    }
}
