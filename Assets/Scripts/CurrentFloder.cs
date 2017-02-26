﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentFloder : MonoBehaviour {
    public FileReader Files;
    CharacterInfos current;

    int index = -1;
    public GameObject g;

    public int badDecisions = 0;
    public int numberFolder = 2;
    public int innocentVictims = 0;

    public int day;
    bool fileInitialized = false;
    
	// Use this for initialization
	void Start () {
        day = 1;
    }
    void Awake()
    {
        DontDestroyOnLoad(this);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update () {

        if(fileInitialized == false)
        {
            index = Random.Range(1, Files.listCharacters.Count);
            Debug.Log("index start:" + index + "count" + Files.listCharacters.Count);
            fileInitialized = true;
        }
    }

    public CharacterInfos GetCurrent()
    {
        current = Files.listCharacters[index];
        return current;
    }
    public void NextFile()
    {
        if(Files.listCharacters[index].outcome == 1 && Files.listCharacters[index].guilty == false)//judged guilty && actually non guilty
        {
            badDecisions++;
            innocentVictims++;
        }
        else if(Files.listCharacters[index].outcome == 2 && Files.listCharacters[index].guilty == true)//judged innocent && actually guilty
        {
            badDecisions++;
        }

        if (Files.listCharacters[index].outcome != 3)
        {
            Files.listCharacters.RemoveAt(index);
        }

        if (day >= 5 && numberFolder == 1)//si c'est le dernier jour et qu'il ne reste qu'un dossier, je tire le mien
        {
            index = 0;
        }

        index = Random.Range(1, Files.listCharacters.Count);
        Debug.Log("Count " + Files.listCharacters.Count + " index " +index);
        current = Files.listCharacters[index];
    }

}
