using UnityEngine;

public class EducationHand : MonoBehaviour
{
    private GameObject m_trackingObject;
    [SerializeField] private string m_nameTrackingObject;
    private Renderer spriteRenderer;
    
    private void Start()
    {
        spriteRenderer = GetComponent<Renderer>();
    }

    public void DisableEnableRender( bool m_renderEducationHand )
    {
        if( m_renderEducationHand )
        {
            spriteRenderer.enabled = true;
        }
        else
        {
            spriteRenderer.enabled = false;
        }
    }

    public void ChangePosition( Vector3 PositionTrackingObject )
    {
        transform.position = PositionTrackingObject;
    }
}
