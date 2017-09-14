using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClicked : MonoBehaviour {

    public GameObject selectedLight;
    public int playerFlag;//1= A , 2=B
    
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        

    }

    void OnMouseDown()
    {
        // this object was clicked - do something
        var groundStatus = GameObject.Find("GameController").GetComponent<GameControl>().groundStatus;
        if (groundStatus == GameControl.GroundStatus.AMoveSelect && playerFlag == 1)
        {
            LightCharacter();
        }
        else if (groundStatus == GameControl.GroundStatus.BMoveSelect && playerFlag == 2)
        {
            LightCharacter();
        }
    }

    void LightCharacter()
    {
        if (GameObject.Find("GameController").GetComponent<GameControl>().Lighting == 1)
        //if(GameObject.Find("GameController").GetComponent<GameControl>().lastLightRec)
        {
            DestroyObject(GameObject.Find("GameController").GetComponent<GameControl>().lastLightRec);
            if (GameObject.Find("GameController").GetComponent<GameControl>().lastLightRec.transform.position == transform.position)
            {
                DestroyObject(GameObject.Find("GameController").GetComponent<GameControl>().lastLightRec);
            }
            else
            {
                DestroyObject(GameObject.Find("GameController").GetComponent<GameControl>().lastLightRec);
                GameObject.Find("GameController").GetComponent<GameControl>().lastLightRec = Instantiate(selectedLight, transform.position, Quaternion.identity);
                GameObject.Find("GameController").GetComponent<GameControl>().selectedCharacter = gameObject;
            }
        }
        else
        {
            GameObject.Find("GameController").GetComponent<GameControl>().lastLightRec = Instantiate(selectedLight, transform.position, Quaternion.identity);
            GameObject.Find("GameController").GetComponent<GameControl>().selectedCharacter = gameObject;
        }
    }

}
