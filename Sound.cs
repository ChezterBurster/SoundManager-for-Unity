using UnityEngine;
using UnityEngine.Audio;

namespace SoundManager {
    
    [CreateAssetMenu(fileName = "new Sound", menuName = "Create Sound", order = 0)]
    public class Sound : ScriptableObject  {

        [SerializeField] private AudioClip clip;
        [SerializeField] private AudioMixerGroup mixerGroup;
        [SerializeField] private RangedFloat volume;
        [SerializeField] private RangedFloat pitch;
    
        public void Play(AudioSource source) {
            source.clip = clip;
            source.outputAudioMixerGroup = mixerGroup;
            source.volume = Random.Range(volume.minValue, volume.maxValue);
            source.pitch = Random.Range(pitch.minValue, pitch.maxValue);
            source.Play();
        }
    
    }
}
