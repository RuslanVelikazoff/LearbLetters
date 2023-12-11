using UnityEngine;
using Plugins.Audio.Core;

[System.Serializable]
public class Sound
{
    public string name;

    [Range(0f, 1f)]
    public float volume;

    public bool loop;

    [HideInInspector]
    public SourceAudio source;
}
