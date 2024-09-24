using UnityEngine;

namespace SoundManager_for_Unity {
    
    //Scriptable padre para heredar propiedades y referenciar en otros objetos
    public abstract class SoundEvent : ScriptableObject  {
        
        public AudioClip clip;              //El clip que se va a reproducir
        [SerializeField] private AudioMixerGroup mixerGroup;  //MixerGroup al que pertenece el clip
    
        //Reproduce el clip
        public abstract void Play(AudioSource source)

    }
}
