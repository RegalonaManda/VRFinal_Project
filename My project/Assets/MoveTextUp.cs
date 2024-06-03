using System.Collections;
using UnityEngine;

public class MoveTextUp : MonoBehaviour
{
    public RectTransform textContainer; // El contenedor que contiene el texto
    public float moveDistance = 1000f; // La distancia que se mover� el texto
    public float moveDuration = 2f; // La duraci�n del movimiento
    public float stopPositionY = -10f; // La posici�n Y donde se detendr� el movimiento

    private bool isMoving = false;

    public void StartMoveUp()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveUpCoroutine());
        }
    }

    private IEnumerator MoveUpCoroutine()
    {
        isMoving = true;

        Vector3 startPos = textContainer.anchoredPosition;
        Vector3 endPos = startPos + Vector3.up * moveDistance;
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration && textContainer.anchoredPosition.y < stopPositionY)
        {
            textContainer.anchoredPosition = Vector3.Lerp(startPos, endPos, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the text stops at the correct position
        if (textContainer.anchoredPosition.y > stopPositionY)
        {
            Vector3 finalPosition = textContainer.anchoredPosition;
            finalPosition.y = stopPositionY;
            textContainer.anchoredPosition = finalPosition;
        }

        isMoving = false;
    }
}
