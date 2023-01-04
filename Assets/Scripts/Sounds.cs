using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class Sounds : MonoBehaviour
{

    private AudioSource _audioSource;
    [SerializeField] private AudioClip rotate ;
    [SerializeField] private AudioClip getPoints ;
    private AudioMixer _audioMixer;
    private void Awake()
    { 
        _audioSource = GetComponent<AudioSource>();
        _audioMixer = _audioSource.outputAudioMixerGroup.audioMixer;
    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _audioMixer.SetFloat("RotatePitch", 1+Random.Range(-0.1f, 0.1f));
            _audioSource.PlayOneShot(rotate);
        }

    }

    public void SoundOff()
    {
        
        
        _audioMixer.GetFloat("MasterVolume", out var volume);
       
        if (volume != 0) 
        {
           _audioMixer.SetFloat("MasterVolume", 0.0f);
        }
        else
        {
            _audioMixer.SetFloat("MasterVolume", -80.0f);
        }
        
    }

    public void PlayGetPointSound()
    {
        _audioSource.PlayOneShot(getPoints);
    }

}

