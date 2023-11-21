using System;
using UnityEngine;


    public class Missile : MonoBehaviour
    {
        [Header("REFERENCES")]
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private Target _target;
        [SerializeField] private Target _newTarget; // Nuevo objetivo
        [SerializeField] private GameObject _explosionPrefab;

    private GameObject explosionInstance;

    [Header("MOVEMENT")]
        [SerializeField] private float _speed = 15;
        [SerializeField] private float _rotateSpeed = 95;

        [Header("PREDICTION")]
        [SerializeField] private float _maxDistancePredict = 100;
        [SerializeField] private float _minDistancePredict = 5;
        [SerializeField] private float _maxTimePrediction = 5;
        private Vector3 _standardPrediction, _deviatedPrediction;

        [Header("DEVIATION")]
        [SerializeField] private float _deviationAmount = 1; // Ajusta la cantidad de desviación
        [SerializeField] private float _deviationSpeed = .1f; // Ajusta la velocida


        private void FixedUpdate()
        {
            _rb.velocity = transform.forward * _speed;

            var leadTimePercentage = Mathf.InverseLerp(_minDistancePredict, _maxDistancePredict, Vector3.Distance(transform.position, _target.transform.position));

            PredictMovement(leadTimePercentage);

            AddDeviation(leadTimePercentage);

            RotateRocket();
        }
        public void ChangeMissileTarget()
        {
            _target = _newTarget; // Cambia el objetivo al nuevo objetivo
        }

        private void PredictMovement(float leadTimePercentage)
        {
            var predictionTime = Mathf.Lerp(0, _maxTimePrediction, leadTimePercentage);

            _standardPrediction = _target.Rb.position + _target.Rb.velocity * predictionTime;
        }

        private void AddDeviation(float leadTimePercentage)
        {
            float lateralDeviation = _deviationAmount * leadTimePercentage * Mathf.Cos(Time.time * _deviationSpeed);
            float verticalDeviation = _deviationAmount * leadTimePercentage * Mathf.Sin(Time.time * _deviationSpeed);

            var deviation = new Vector3(lateralDeviation, verticalDeviation, 0);

            var predictionOffset = transform.TransformDirection(deviation);

            _deviatedPrediction = _standardPrediction + predictionOffset;
        }


        private void RotateRocket()
        {
            var heading = _deviatedPrediction - transform.position;

            var rotation = Quaternion.LookRotation(heading);
            _rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, _rotateSpeed * Time.deltaTime));
        }

    private void OnCollisionEnter(Collision collision)
    {
        if (_explosionPrefab)
        {
            explosionInstance = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);

            // Destruye la instancia de la explosión después de un cierto tiempo (por ejemplo, 2 segundos)
            Destroy(explosionInstance, 2f);
        }

        if (collision.transform.TryGetComponent<IExplode>(out var ex)) ex.Explode();

        if (collision.gameObject.CompareTag("Shield"))
        {
            explosionInstance = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);

            // Destruye la instancia de la explosión después de un cierto tiempo (por ejemplo, 2 segundos)
            Destroy(explosionInstance, 2f);
            Debug.Log("Colisionó con un objeto con el tag 'Shield'");
        }


        Destroy(gameObject);
    }

    private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, _standardPrediction);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(_standardPrediction, _deviatedPrediction);
        }
    }
