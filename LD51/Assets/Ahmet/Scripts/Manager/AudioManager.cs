using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Sound
{

    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 0.7f;
    [Range(0.5f, 1.5f)]
    public float pitch = 1f;
    [Range(0f, 0.5f)]
    public float randomVolume = 0.1f;
    [Range(0f, 0.5f)]
    public float randomPitch = 0.1f;

    public bool loop = false;


    public AudioSource source;

    public void setSource(AudioSource source)
    {
        this.source = source;
        this.source.clip = this.clip;
        this.source.loop = loop;
    }

    public void Play()
    {
        source.volume = volume * (1 + Random.Range(-randomVolume / 2f, randomVolume / 2f));
        source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));
        this.source.Play();
    }

    public void Stop()
    {
        this.source.Stop();
    }

}

[System.Serializable]
public class Music
{

    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 0.7f;
    [Range(0.0f, 1.5f)]
    public float pitch = 1f;
    [Range(0f, 0.5f)]
    public float randomVolume = 0.1f;
    [Range(0f, 0.5f)]
    public float randomPitch = 0.1f;

    public bool loop = false;


    public AudioSource source;

    public void setSource(AudioSource source)
    {
        this.source = source;
        this.source.clip = this.clip;
        this.source.loop = loop;
    }

    public void Play()
    {
        source.volume = volume * (1 + Random.Range(-randomVolume / 2f, randomVolume / 2f));
        source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));
        this.source.Play();
    }

    public void Stop()
    {
        this.source.Stop();
    }

}

public class AudioManager : MonoBehaviour
{

    public enum State { mainMenu, City, Game, Died };
    public State state = State.mainMenu;

     public enum Diff { begginer, mid, hard };
    public Diff diff = Diff.begginer;
    public static AudioManager instance;
    [SerializeField] public Sound[] sounds;
    [SerializeField] public Music[] musics;

    private void Awake()
    {
        if (instance != null)
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

    }
    private void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            _go.transform.SetParent(this.transform);
            sounds[i].setSource(_go.AddComponent<AudioSource>());
        }
        for (int i = 0; i < musics.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + musics[i].name);
            _go.transform.SetParent(this.transform);
            musics[i].setSource(_go.AddComponent<AudioSource>());
        }
        PlayMusic("MainMenuMusic");
    }

    public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Play();
                Debug.Log(sounds[i].name + " Çalınıyor");
                return;
            }
        }

        //no sound with name
        Debug.LogWarning("Audio Manager : Sound not found in list : " + _name);
    }

    public void StopSound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Stop();
                return;
            }
        }

        //no sound with name
        Debug.LogWarning("Audio Manager : Sound not found in list : " + _name);
    }

    public void PlayMusic(string _name)
    {
        for (int i = 0; i < musics.Length; i++)
        {
            if (musics[i].name == _name)
            {
                musics[i].Play();
                return;
            }
        }

        //no musics with name
        Debug.LogWarning("Audio Manager : Sound not found in list : " + _name);
    }


    int currentMusic;
    public void PlayMusic()
    {
        int RandomMusic = Random.Range(2, musics.Length);
        currentMusic = RandomMusic;
        musics[RandomMusic].Play();

        //no musics with name
        Debug.Log("Audio Manager : Playing this music : " + musics[RandomMusic].name);
    }


    public void StopMusic(string _name)
    {
        for (int i = 0; i < musics.Length; i++)
        {
            if (musics[i].name == _name)
            {
                musics[i].Stop();
                return;
            }
        }

        //no musics with name
        Debug.LogWarning("Audio Manager : Sound not found in list : " + _name);
    }


    public void StopAllMusics()
    {
        foreach (var music in musics)
        {
            music.Stop();
        }
    }
    private void FixedUpdate()
    {
        ControlMusicPlay();
    }

    public void ControlMusicPlay()
    {
        if (!musics[currentMusic].source.isPlaying && state == State.Game)
        {
            PlayMusic();
        }
    }

    public void SceneStatus()
    {
        if (state == State.mainMenu)
        {
            PlayMusic("MainMenuMusic");
        }
        else if (state == State.City)
        {
            PlayMusic("CityMusic");
        }
        else if (state == State.Game)
        {
            PlayMusic();
        }
        Debug.Log("Sahne = " + state);
    }
}
