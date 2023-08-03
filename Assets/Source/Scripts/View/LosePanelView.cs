using UnityEngine;

public class LosePanelView : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    
    public void Visualize()
    {
        _panel.SetActive(true);
    }
}
