using Cinemachine;
using UnityEngine;
using DG.Tweening;
using MKDir;

namespace Manager.Cinemachine
{
    [RequireComponent(typeof(CinemachineImpulseSource))]
    public class CinemachineManager : MonoSingleton<CinemachineManager>
    {

        [SerializeField] private CinemachineImpulseSource _impulseSource;
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        [SerializeField] private float _defaultZoom = 60;

        /// <summary>
        /// 카메라 흔들기
        /// </summary>
        /// <param name="force">흔드는 힘</param>
        public void ShakeCamera(float force)
        {
            if (!_virtualCamera.gameObject.TryGetComponent(out CinemachineImpulseListener impulseListener))
            {
                Debug.LogError("CinemachineImpulseListener 컴포넌트가 없습니다.");
                return;
            }
            _impulseSource.GenerateImpulse(force);
        }

        /// <summary>
        /// 카메라 줌
        /// </summary>
        /// <param name="value">목표 줌</param>
        public void ZoomCamera(float value)
        {
            _virtualCamera.m_Lens.FieldOfView = value;
        }

        /// <summary>
        /// 카메라 줌 with Tween
        /// </summary>
        /// <param name="value">목표 줌 양</param>
        /// <param name="duration">Tween 시간</param>
        /// <param name="ease">Tween Easing</param>
        public void ZoomCameraWithTween(float value, float duration, Ease ease = Ease.Unset)
        {
            DOTween.To(() => _virtualCamera.m_Lens.FieldOfView, x => _virtualCamera.m_Lens.FieldOfView = x, value, duration);
        }
    
        /// <summary>
        /// 카메라 리셋
        /// </summary>
        public void ResetCamera()
        {
            _virtualCamera.m_Lens.FieldOfView = _defaultZoom;
        }
    }
}
