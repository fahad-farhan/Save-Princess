﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPanel : MonoBehaviour
{
    public Transform[] levelItemLst = new Transform[20];
    [HideInInspector]
    public int currentPage = 0,totalPage;

    public Text pageText;

    public Sprite unlockLevel,lockLevel;
    private void Awake()
    {
       currentPage = (int)(PlayerPrefs.GetInt("LockLevel")/ 20);
    }
    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log("Item total " + GetChildByName("Holder").transform.childCount);
        for (int i = 0; i < GetChildByName("Holder").transform.childCount; i++)
            levelItemLst[i] = GetChildByName("Holder").transform.GetChild(i);
        ShowLevelItemInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadItem()
    {
        
    }

    GameObject GetChildByName(string _name)
    {
        GameObject _child = null;
        Transform[] ts = gameObject.GetComponentsInChildren<Transform>();
        if (ts == null)
            return _child;
        foreach (Transform t in ts)
        {
            if (t != null && t.gameObject != null)
            {
                if (t.gameObject.name == _name)
                    _child = t.gameObject;

            }
        }

        return _child;
       
    }

    public void ShowLevelItemInfo()
    {
        pageText.text = "PAGE " + (currentPage + 1).ToString();
        int _lockLevel = PlayerPrefs.GetInt("LockLevel");
        for(int i = 0; i < levelItemLst.Length; i++)
        {
            levelItemLst[i].Find("LevelText").GetComponent<Text>().text = (i + 1 + levelItemLst.Length * currentPage).ToString() + "";
            if (i + 1 + levelItemLst.Length * currentPage <= _lockLevel)
                levelItemLst[i].Find("Panel").GetComponent<Image>().sprite = unlockLevel;
            else
                levelItemLst[i].Find("Panel").GetComponent<Image>().sprite = lockLevel;
            //levelItemLst[i].GetComponent<Button>().onClick.AddListener(() => LoadLevel(i));
            /*
            levelItemLst[i].GetComponent<Button>().onClick.AddListener(() => {

                UIManager._instance.LoadLevel((i));
            
            });
            */
        }
    }

    public void LoadLevel(int _level)
    {
        if(_level <= PlayerPrefs.GetInt("LockLevel"))
         HomeManager._instance.LoadLevel(_level + levelItemLst.Length * currentPage);
    }

    public void NextPage()
    {
        if (currentPage < totalPage - 1)
        {
            currentPage++;
            ShowLevelItemInfo();
        }
           
    }

    public void PrePage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            ShowLevelItemInfo();
        }
           
    }
}
