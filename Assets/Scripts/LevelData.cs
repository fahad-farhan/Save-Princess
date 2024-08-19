using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public List<GameObject> pooledObjects;

    public static LevelData _instance;

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddObject(GameObject _item)
    {
        pooledObjects.Add(_item);
    }


    public void CleanAlllObjects()
    {
        foreach (GameObject _child in pooledObjects)
            Destroy(_child);
        pooledObjects.Clear();
    }
}
