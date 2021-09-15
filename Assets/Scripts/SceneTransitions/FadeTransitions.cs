using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeTransitions : MonoBehaviour {

    public Animator animator;

    private int levelToLoad;

    public GameObject uiManager;

    private MusicController changeTrack;


    // Update is called once per frame
    private void Start()
    { 
        
    }

    void Update () {
            
	}

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
        Destroy(uiManager);
    }

    public void FadeOnComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
