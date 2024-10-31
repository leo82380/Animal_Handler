using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Manager.PP
{
    public class PostProcessingManager : MonoBehaviour
    {
        [SerializeField] private Volume _volume;
        [SerializeField] private Bloom _bloom;
        [SerializeField] private Vignette _vignette;
        
        private void Awake()
        {
            _volume.profile.TryGet(out _bloom);
            _volume.profile.TryGet(out _vignette);
        }
        
        /// <summary>
        /// 포스트 프로세싱 활성화 여부 설정
        /// </summary>
        /// <param name="value">Active</param>
        public void SetPostProcessingActive(bool value)
        {
            _volume.enabled = value;
        }
        
        /// <summary>
        /// 블룸 강도 설정
        /// </summary>
        /// <param name="value">블룸 강도</param>
        public void SetBloomIntensity(float value)
        {
            _bloom.intensity.value = value;
        }
        
        /// <summary>
        /// Vignette의 강도 설정(커질수록 어두워짐)
        /// </summary>
        /// <param name="value">강도</param>
        public void SetVignetteIntensity(float value)
        {
            _vignette.intensity.value = value;
        }

        /// <summary>
        /// Vignette의 강도 설정 with Tween(커질수록 어두워짐)
        /// </summary>
        /// <param name="value">목표 강도</param>
        /// <param name="duration">Tween 시간</param>
        /// <param name="ease">Tween Easing</param>
        public void SetVignetteIntensity(float value, float duration, Ease ease = Ease.Unset)
        {
            DOTween.To(() => _vignette.intensity.value, x => _vignette.intensity.value = x, value, duration).SetEase(ease);
        }
        
        /// <summary>
        /// Vignette의 색상 설정
        /// </summary>
        /// <param name="value">Vignette 색</param>
        public void SetVignetteColor(Color value)
        {
            _vignette.color.value = value;
        }

        /// <summary>
        /// Vignette의 색상 설정 with Tween
        /// </summary>
        /// <param name="value">목표 색깔</param>
        /// <param name="duration">Tween 지속시간</param>
        /// <param name="ease">Tween Easing</param>
        public void SetVignetteColor(Color value, float duration, Ease ease = Ease.Unset)
        {
            DOTween.To(() => _vignette.color.value, x => _vignette.color.value = x, value, duration).SetEase(ease);
        }
    }
}
