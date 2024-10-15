using System;
using SoundManagerAPI.SoundEvents;
using UnityEngine;

namespace SoundManagerAPI
{
    #region Sound Event Manager
    /// <summary>
    /// This class is responsible for managing sound events and triggering them
    /// It uses a static event to trigger the sound events
    /// Any class that wants to trigger a sound event should subscribe to the event and implement the HandleSoundTrigger method
    /// </summary>
    public static class SoundEventManager
    {
        public static event Action OnSoundTrigger;

        public static void TriggerSound()
        {
            OnSoundTrigger?.Invoke();
        }
    }
    #endregion

    #region Interface to Inherit on any class that uses SoundEvents
    //The interface is used to implement event based calling
    public interface ISoundEventSubscriber
    {
        void SubscribeToSoundManager()
        {
        }

        void UnsubscribeFromSoundManager()
        {
        }

        void HandleSoundTrigger()
        {
        }
    }
    #endregion

    #region GameObjectExample
    public class GameObjectExample : MonoBehaviour, ISoundEventSubscriber
    {
        [SerializeField] private SfxEvent sfxEvent; //Reference to the scriptableobject file, could be a MusicEvent instead
        private AudioSource audioSource; //An audiosource is needed, does not have to be a component attached to the same object

        private void Awake() => audioSource = GetComponent<AudioSource>(); //In our case we initialize the reference from a component

        //Make sure to subscribe and unsubscribe according to your needs
        private void OnEnable() => SubscribeToSoundManager();
        private void OnDisable() => UnsubscribeFromSoundManager();

        //Implement the interface methods
        private void SubscribeToSoundManager() => SoundEventManager.OnSoundTrigger += HandleSoundTrigger;

        private void UnsubscribeFromSoundManager() => SoundEventManager.OnSoundTrigger -= HandleSoundTrigger;

        private void HandleSoundTrigger()
        {
            sfxEvent?.Play(audioSource);
        }
    }
    #endregion
}