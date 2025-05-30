using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillImage;
    public Transform followTarget; // enemy or building
    public Vector3 offset = new Vector3(0, 2f, 0);

    void Update()
    {
        if (followTarget != null)
        {
            transform.position = followTarget.position + offset;
            transform.forward = Camera.main.transform.forward; // Face camera
        }
    }

    public void SetHealth(float current, float max)
    {
        if (fillImage != null)
        {
            fillImage.fillAmount = Mathf.Clamp01(current / max);
            Debug.Log($"Health bar updated: {fillImage.fillAmount}");
        }
    }
}
