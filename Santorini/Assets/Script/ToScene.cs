using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToScene : MonoBehaviour {
	public void ToLocalGame()
    {
        SceneManager.LoadScene("LocalGame");
    }
    public void ToOpening()
    {
        SceneManager.LoadScene("Opening");
    }
    public void ToNetwork()
    {
        SceneManager.LoadScene("NetworkGame");
    }
}
