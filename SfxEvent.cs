using UnityEngine;
using UnityEngine.Audio;

namespace SoundManager_for_Unity {
	
	[CreateAssetMenu(fileName = "New SfxEvent", menuName = "SoundEvent/SfxEvent", order = 1)]
	public class SfxEvent : SoundEvent {
		
		[SerializeField] private RangedFloat volume;	//Rango de valores para el volumen
		[SerializeField] private RangedFloat pitch;		//Rango de valores para el pitch

		// Reproduce el sonido
		public override void Play(AudioSource source) {
			source.clip = clip;
			source.outputAudioMixerGroup = mixerGroup;
			//Usa valores aleatorios dentro del rango para añadir variaciones
			source.volume = Random.Range(volume.minValue, volume.maxValue);
			source.pitch = Random.Range(pitch.minValue, pitch.maxValue);
			source.Play();
		}
	}
}