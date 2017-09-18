using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl: MonoBehaviour {
    public enum GroundStatus {
        GameBegin,AMoveSelect,ABuildSelect,BMoveSelect,BBuildSelect, EndPhrase
    }
    public GroundStatus groundStatus;
    // 1 = GameBegin
    // 2 = A MoveSelect
    // 3 = A BuildSelect
    // 4 = B MoveSelect
    // 5 = B BuildSelect
    int APosition;
    int BPosition;
    public AudioClip BGM;
    public AudioClip voiceBuild;
    public AudioClip voiceClimb;
    public int [,]groundMap=new int[5,5]; //number = Floor 0,1,2,3,4(roof)
    public int [,]playerMap = new int[5, 5]; //map for player's position
    public Text phraseMsg;
    public GameObject selectedCharacter;
    //public float groundX;
    //public float groundZ;
    public GameObject groundPrefab;
    public GameObject planePrefab;
    public GameObject p1Prefab;
    public GameObject p2Prefab;
    public GameObject housePrefab;
    public GameObject tempGO;
    public float groundDistance;
    public int Lighting { get { return lastLightRec != null ? 1: 0 ; } }
    public GameObject lastLightRec;
    int characterSet=0;
    // Use this for initialization
    void Start () {
        GroundInit();
        groundStatus = GroundStatus.GameBegin;
        phraseMsg = GameObject.Find("Phrase").GetComponent<Text>();
        //Debug.Log(groundX+","+groundZ);
    }
	
	// Update is called once per frame
	public void setPlayerPosition (float groundX, float groundZ ) {
        Debug.Log(groundX + "," + groundZ);
            
        if (characterSet == 3)
        {
            GameObject tempGO = Instantiate(p2Prefab, new Vector3(groundX, 1, groundZ), Quaternion.identity);
            tempGO.GetComponent<CharacterClicked>().playerFlag = 2;
            characterSet++;
            groundStatus = GroundStatus.AMoveSelect;
            phraseMsg.text = "Phrase : A Move Turn";
            playerMap[(int)groundX/4, (int)groundZ/4] = 1;
        }
        if (characterSet == 2) //second A
        {
            GameObject tempGO = Instantiate(p1Prefab, new Vector3(groundX, 1, groundZ), Quaternion.identity);
            tempGO.GetComponent<CharacterClicked>().playerFlag = 1;
            characterSet++;
            playerMap[(int)groundX / 4, (int)groundZ / 4] = 1;
        }
        if (characterSet == 1)
        {
            GameObject tempGO = Instantiate(p2Prefab, new Vector3(groundX, 1, groundZ), Quaternion.identity);
            tempGO.GetComponent<CharacterClicked>().playerFlag = 2;
            characterSet++;
            playerMap[(int)groundX / 4, (int)groundZ / 4] = 1;
        }
        if (characterSet==0) //first A
        {
            GameObject tempGO = Instantiate(p1Prefab, new Vector3(groundX, 1, groundZ), Quaternion.identity);
            tempGO.GetComponent<CharacterClicked>().playerFlag = 1;
            characterSet++;
            playerMap[(int)groundX / 4, (int)groundZ / 4] = 1;
        }      
	}

    void GroundInit()
    {
        for(int i=0; i<5 ; i++)
        {
            for(int j=0; j<5 ; j++)
            {
                Instantiate(groundPrefab, new Vector3(i, 0, j)*groundDistance, Quaternion.identity);
            }
        }
        Instantiate(planePrefab, new Vector3(2, 0, 2) * groundDistance, Quaternion.identity);
        //Instantiate(housePrefab, new Vector3(2, 0.3f, 2) * groundDistance, Quaternion.identity);
    }
}
