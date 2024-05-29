using UnityEngine;

public class Target : MonoBehaviour
{
    private Level4Logic level4logic;

    private void Start()
    {
        level4logic = FindObjectOfType<Level4Logic>();
        if (level4logic == null)
        {
            Debug.LogError("Level4Logic not found in the scene.");
        }
        Debug.Log("Level4Logic found in the scene.");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("target hit");
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Destruye la diana al ser impactada por una bala
            Debug.Log("target hit");
            level4logic.TargetsShot += 1;
            level4logic.CheckRemainingTargets();
            Destroy(gameObject);
        }
    }
}
