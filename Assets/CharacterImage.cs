using System.Collections;
using UnityEngine;

public class CharacterImage : MonoBehaviour
{
    public float jumpScale = 1.2f;
    public float duration = 0.2f;
    public IEnumerator JumpAnim()
    {
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = originalScale * jumpScale;

        float t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            float progress = t / duration;
            // ease out then in
            float scale = Mathf.Sin(progress * Mathf.PI);
            transform.localScale = Vector3.Lerp(originalScale, targetScale, scale);
            yield return null;
        }

        transform.localScale = originalScale;

        Debug.Log("Jump");
    }
}
