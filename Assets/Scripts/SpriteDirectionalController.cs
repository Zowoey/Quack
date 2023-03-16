
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] Transform mainTransform;
    [SerializeField] float backAngle = 65;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    private void LateUpdate()
    {
        Vector3 camForwardVector = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z);

        float signedAngle = Vector3.SignedAngle(mainTransform.forward, camForwardVector, Vector3.up);

        Vector2 animationDirection = new Vector2(0f, -1f);
        float angle = Mathf.Abs(signedAngle);
    }

}
