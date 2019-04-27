using System.Collections;
using UnityEngine;

namespace Asteroids.UI
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField]
        private float _shakeIntensity = 0;

        [SerializeField]
        private float _playerShakeDuration = 0;

        [SerializeField]
        private float _enemyShakeDuration = 0;

        private float _shakeDuration;
        private Vector3 _originalPos;
        private Coroutine _shakeCameraCoroutine;

        private void Start()
        {
            _shakeDuration = 0;
            _originalPos = transform.localPosition;
        }

        private void OnEnable()
        {
            MessageManager.Instance.AddListener<PlayerAttackMessage>(OnPlayerAttackMessage);
            MessageManager.Instance.AddListener<EnemyAttackMessage>(OnEnemyAttackMessage);
        }

        private void OnDisable()
        {
            MessageManager.Instance.RemoveListener<PlayerAttackMessage>(OnPlayerAttackMessage);
            MessageManager.Instance.RemoveListener<EnemyAttackMessage>(OnEnemyAttackMessage);
        }

        private void ShakeCamera()
        {
            if(_shakeCameraCoroutine != null)
            {
                StopCoroutine(_shakeCameraCoroutine);
            }
            _shakeCameraCoroutine = StartCoroutine(ShakeCameraCoroutine());
        }
        
        private IEnumerator ShakeCameraCoroutine()
        {
            while(_shakeDuration > 0)
            {
                yield return null;
                transform.localPosition = _originalPos + Random.insideUnitSphere * _shakeIntensity;
                _shakeDuration -= Time.deltaTime;
            }

            _shakeDuration = 0;
            transform.localPosition = _originalPos;
        }

        private void OnPlayerAttackMessage(PlayerAttackMessage message)
        {
            _shakeDuration = _playerShakeDuration;
            ShakeCamera();
        }

        private void OnEnemyAttackMessage(EnemyAttackMessage message)
        {
            _shakeDuration = _enemyShakeDuration;
            ShakeCamera();
        }
    }
}