# SoundManager for Unity

This repository provides a simple API to manage audio files in Unity using an event-based system and ScriptableObject management for sound data.

Features
>Event-Based Audio System: Trigger and manage sounds using events for clean, decoupled code.
>ScriptableObject Management: Store and manage sound data in ScriptableObjects for easy configuration and reuse.
>Easy Integration: Quickly integrate into any Unity project.

Getting Started
>To implement this SoundManager in your project, follow these steps:

    1. Clone or download the repository.
    2. Add the SoundManager.cs file to your project.
    3. Review the code in SoundManager.cs for guidance on how to call and manage sounds in your game.
    4. Usage Example

Here's a basic example of how to use the SoundManager:

    // Define a method to handle the sound trigger event
    private void HandleSoundTrigger()
    {
        // Play the sound event through the assigned AudioSource
        sfxEvent?.Play(audioSource);
    }
    // Subscribe to the event in the EventManager
    SoundEventManager.OnSoundTrigger += HandleSoundTrigger;
    // Trigger the sound event (wherever appropriate in your game logic)
    SoundEventManager.TriggerSound();

Requirements
>Unity 2022.3.33f or higher.
>Basic understanding of Unity's Event System and ScriptableObjects.

References
This API is based on concepts from the video tutorial: [Unite 2016 - Overthrowing the MonoBehaviour Tyranny in a Glorious Scriptable Object Revolution](https://www.youtube.com/watch?v=6vmRwLYWNRo)

Contributing
Feel free to submit issues or pull requests to improve this project.