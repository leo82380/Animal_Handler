using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    [SerializeField] private Image _fadeImage;
    
    /// <summary>
    /// 이미지 페이드
    /// </summary>
    /// <param name="targetValue">목표 페이드 값</param>
    /// <param name="duration">Tween 시간</param>
    /// <param name="ease">Tween Easing</param>
    public void Fade(float targetValue, float duration, Ease ease = Ease.Unset)
    {
        _fadeImage.DOFade(targetValue, duration).SetEase(ease);
    }
}