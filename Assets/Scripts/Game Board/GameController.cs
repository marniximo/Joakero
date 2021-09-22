using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<GameObject> characters;
    public GameObject currentTurnCharacter = null;
    public const int maxProgression = 100;
    public bool started = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (started) {
            foreach (var character in characters)
            {
                var characterComponent = character.GetComponent<CharacterManager>();
                var speed = characterComponent.speed;
                if (currentTurnCharacter == null)
                {
                    characterComponent.progression += speed * Time.deltaTime;
                    if (characterComponent.progression >= maxProgression)
                    {
                        currentTurnCharacter = character;
                        characterComponent.selected = true;
                    }
                }
            }
        }
    }

    public void UseTurn() {
        var characterComponent = currentTurnCharacter.GetComponent<CharacterManager>();
        characterComponent.selected = false;
        characterComponent.progression = 0;
        currentTurnCharacter = null;
    }

    public void StartGame() {
        var arr = GameObject.FindGameObjectsWithTag("Character");
        foreach (var obj in arr)
        {
            characters.Add(obj);
        }
        started = true;
    }
}
