using UnityEngine;

public class MODSScript : MonoBehaviour
{
    // Reference to GameManager to modify its properties
    private GameManager gameManager;

    private void Awake()
    {
        // Ensure this object is not destroyed on load
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Find the GameManager instance
        gameManager = GameManager.GM;
    }

    private void Update()
    {
        // Check if the F key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Set enemyWeakpointsDestroyed to 3
            if (gameManager != null)
            {
                gameManager.enemyWeakpointsDestroyed = 3;
            }
        }

        // Check if the G key is pressed
        if (Input.GetKeyDown(KeyCode.G))
        {
            // Set allyWeakpointsDestroyed to 3
            if (gameManager != null)
            {
                gameManager.allyWeakpointsDestroyed = 3;
            }
        }
    }
}