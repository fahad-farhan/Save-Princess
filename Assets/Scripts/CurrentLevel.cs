using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentLevel : MonoBehaviour
{
    [HideInInspector]
    public Player _hero;

    public static CurrentLevel _instance;

    bool isLoadedHero;


    private void Awake()
    {
        _instance = this;
         isLoadedHero = false;
    }
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isLoadedHero && _hero == null)
        {
            _hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<Player>();
            isLoadedHero = true;
        }
    }
}
