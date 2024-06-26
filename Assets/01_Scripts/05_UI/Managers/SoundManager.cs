using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource bgmSound;
    public AudioSource sfxSound;
    public AudioClip[] bgList;
    public AudioClip buttonSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //SceneManager.sceneLoaded += SceneManager_sceneLoaded;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        BgSoundPlay(bgList[0]);
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        //for(int i = 0; i < bgList.Length; i++)
        //{
        //    if(arg0.name.Substring(arg0.name.Length - 1 ) == bgList[i].name) 
        //    {
        //        BgSoundPlay(bgList[i]);
        //    }
        //}


        BgSoundPlay(bgList[0]);
    }

    private void BgSoundPlay(AudioClip clip)
    {
        if (clip == null) return;

        bgmSound.clip = clip;
        bgmSound.loop = true;
        bgmSound.Play();
    }

    public void ButtonSoundPlay()
    {
        if (buttonSound == null) return;

        sfxSound.clip = buttonSound;
        sfxSound.loop = false;
        sfxSound.Play();
    }

}
