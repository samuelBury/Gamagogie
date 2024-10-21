using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolCommunicationGameManager : MonoBehaviour
{

    [SerializeField] private GameObject FileSpawnPos;
    [SerializeField] private GameObject FilePlacementPos;
    [SerializeField] private GameObject fileSpritePrefabs;

    

    private GameObject fileSprite;

    
    void Start()
    {
        newFile();
    }

    
    void Update()
    {
        
    }
    void newFile()
    {
        fileSprite = Instantiate(fileSpritePrefabs);
        fileSprite.GetComponent<Drop>().fileSpawn = FileSpawnPos.transform;
        fileSprite.GetComponent<Drop>().filePlacement = FilePlacementPos.transform;
        fileSprite.transform.localPosition = FileSpawnPos.transform.position;
    

        
    }
}
