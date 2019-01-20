using UnityEngine;

public class MusicPlayer : MonoBehaviour
{   
	void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
