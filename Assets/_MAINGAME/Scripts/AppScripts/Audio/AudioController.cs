using APP.AppScripts.Utilities.DataStructures;
using Assets._MAINGAME.Scripts.AppScripts.Constants;
using Unity.VisualScripting;
using UnityEngine;

namespace _MAINGAME.Scripts.AppScripts.Audio
{
    [Singleton]
    public class AudioController: MonoBehaviour
    {
        [SerializeField] private AudioSource musicBgSource;
        [SerializeField] private AudioSource sfxSource;
        [SerializeField] private SerializableDictionary<Music, AudioClip> musicSounds;
        [SerializeField] private SerializableDictionary<Sfx, AudioClip> sfxSounds;
    }
}
