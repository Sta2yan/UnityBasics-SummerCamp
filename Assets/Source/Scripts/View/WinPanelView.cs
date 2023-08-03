using UnityEngine;

public class WinPanelView : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    public void Visualize()
    {
        _panel.SetActive(true);
    }
}
