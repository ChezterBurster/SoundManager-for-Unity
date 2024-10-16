﻿using UnityEngine;

namespace SoundManagerAPI.SoundEvents
{
	[CreateAssetMenu(fileName = "New MusicEvent", menuName = "SoundEvent/MusicEvent", order = 0)]
	public class MusicEvent : SoundEvent
	{
		[SerializeField][Range(0f, 1f)] private float volume;   //Volumen del clip de Musica
		[SerializeField][Range(0.1f, 1.5f)] private float pitch;  //Cambio de tono 

		//Reproduce el clip de musica en loop
		public override void Play(AudioSource source)
		{
			source.clip = clip;
			source.outputAudioMixerGroup = mixerGroup;
			source.volume = volume;
			source.pitch = pitch;
			source.Play();
		}
	}
}