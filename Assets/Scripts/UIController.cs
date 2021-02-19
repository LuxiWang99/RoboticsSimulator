using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Rover rover;
    public floorControl floorController;
    public Text roverPosText;
    public Button spawnObstacleButton;

    private void Start()
    {
        spawnObstacleButton.onClick.AddListener(SpawnObstacle);
    }

    private void Update()
    {
        PrintRoverPosition();
    }

    private void SpawnObstacle()
    {
        float x = int.Parse("1");
        float y = int.Parse("1");
        Vector3 obstaclePos = new Vector3(x, 0.5f, y);
        floorController.AddObstacle(obstaclePos);
    }

    private void PrintRoverPosition()
    {
        Vector3 roverPos = rover.transform.position;
        roverPosText.text = string.Format("Pos=({0:0.0}, {1:0.0})\nθ={2:0.0}°", roverPos.x, roverPos.z, rover.transform.rotation.eulerAngles.y);
    }
}
