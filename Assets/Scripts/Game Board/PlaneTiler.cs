using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneTiler : MonoBehaviour
{
    public GameController gameController;
    public GameObject hexagonPrefab;
    public const int SIZEX = 8;
    public const int SIZEY = 10;
    public GameObject[,] boardMatrix = new GameObject[SIZEY, SIZEX];
    public GameObject[,] charactersMatrix = new GameObject[SIZEY, SIZEX];
    public List<GameObject> characterPrefabs;
    public List<Vector3Int> characters; //x, y, characterIndex

    // Start is called before the first frame update
    void Start()
    {
        TilePlane();
        PlaceCharacters();
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TilePlane() {
        for (int i = 0; i < SIZEY; i++) {
            for (int j = 0; j < SIZEX; j++) {
                var position = new Vector3(j * 1.8f + 0.875f * (i % 2), 0, i*1.6f);
                //var rotation = new Quaternion(0.70f, 0, 0, 0.70f);
                var rotation = hexagonPrefab.transform.rotation;
                var hexagon = Instantiate(hexagonPrefab, position, rotation);
                boardMatrix[i, j] = hexagon;
                charactersMatrix[i, j] = null;
                hexagon.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(Random.value*2, Random.value*2));
            }
        }
    }

    void PlaceCharacters()
    {
        foreach (var character in characters) {
            if (charactersMatrix[character.y, character.x] == null) {
                var position = new Vector3(
                    boardMatrix[character.y, character.x].transform.position.x,
                    0.7f, 
                    boardMatrix[character.y, character.x].transform.position.z
                );
                var characterInstance = Instantiate(
                    characterPrefabs[character.z],
                    position,
                    characterPrefabs[character.z].transform.rotation
                );
                charactersMatrix[character.y, character.x] = characterInstance;
                characterInstance.GetComponent<CharacterManager>().gameController = gameController;
            }
        }
    }

    void StartGame() {
        gameController.StartGame();
    }
}
