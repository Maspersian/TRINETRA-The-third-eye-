using UnityEngine;

public class DragPiece : MonoBehaviour
{
    public int pieceID;

    private Transform snapTarget;
    private bool dragging;
    private bool snapped;
    private Vector3 offset;

    void Start()
    {
        // Find the correct shadow automatically
        ShadowID[] shadows =
            FindObjectsByType<ShadowID>(FindObjectsSortMode.None);

        foreach (ShadowID shadow in shadows)
        {
            if (shadow.id == pieceID)
            {
                snapTarget = shadow.transform;
                break;
            }
        }

        if (snapTarget == null)
        {
            Debug.LogError(
                $"No snap target found for pieceID {pieceID} on {name}"
            );
        }
    }

    void Update()
    {
        if (snapped || snapTarget == null) return;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorld = GetMouseWorldPosition();
            RaycastHit2D hit = Physics2D.Raycast(mouseWorld, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                offset = DragManager.Instance.useOffset
                    ? transform.position - mouseWorld
                    : Vector3.zero;

                dragging = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
            TrySnap();
        }

        if (dragging)
        {
            transform.position = GetMouseWorldPosition() + offset;
        }
    }

    void TrySnap()
    {
        float dist = Vector2.Distance(transform.position, snapTarget.position);

        if (dist <= DragManager.Instance.snapDistance)
        {
            transform.position = snapTarget.position;
            snapped = true;

            DragManager.Instance.PlaySnapSound();
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 m = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        m.z = DragManager.Instance.dragZ;
        return m;
    }
}
