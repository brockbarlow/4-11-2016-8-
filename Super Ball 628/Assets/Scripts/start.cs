using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour {

	public void OnClick()
    {
        SceneManager.LoadScene("Level 1");
    }
}