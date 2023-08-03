using UnityEngine;
using UnityEngine.UI;

public class TimeCountView : MonoBehaviour
{
    private const float FillMaximum = 1f;
    
    [SerializeField] private TimeCount _timeCount;
    [SerializeField] private Image _timer;

    private void Update()
    {
        Visualize();
    }

    private void Visualize()
    {
        _timer.fillAmount = FillMaximum - _timeCount.CurrentTime / _timeCount.TargetInSeconds;
    }
}
