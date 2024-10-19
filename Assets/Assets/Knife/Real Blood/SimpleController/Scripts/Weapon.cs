using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knife.RealBlood.SimpleController
{
    /// <summary>
    /// Simple weapon behaviour without reloading and recoil
    /// </summary>
    public class Weapon : MonoBehaviour
    {
        public Camera playerCamera;
        public LayerMask ShotMask;
        public float Damage = 10f;

        public float DefaultFov = 60f;
        public float AimFov = 35f;
        public bool AutomaticFire;
        public float AutomaticFireRate = 10;

        protected Animator handsAnimator;

        bool isAiming = false;

        public CameraShake cameraShake; 
        [field:SerializeField]public virtual float shakeDuration { get; set; } = .08f;
        [field: SerializeField] public virtual float shakeMagnitude { get; set; } = 0.05f;

        [SerializeField] InputSystemPlayer player;
        bool shooting = false;

        float currentFov;

        float lastFireTime;
        float fireInterval
        {
            get
            {
                return 1f / AutomaticFireRate;
            }
        }

        public float CurrentFov
        {
            get
            {
                return currentFov;
            }
        }

        private void Awake()
        {
            //player = GetComponentInParent<InputSystemPlayer>();
            
        }

        private void OnEnable()
        {
            player.shootEvent += OnShooting;
        }

        void Start()
        {
            handsAnimator = GetComponent<Animator>();
            lastFireTime = -fireInterval;
        }

        private void OnDisable()
        {
            currentFov = DefaultFov;
            player.shootEvent -= OnShooting;
        }

        private void OnShooting()
        {
            shooting = true;
        }

        void Update()
        {
            if (AutomaticFire)
            {
                if (shooting && Time.time > lastFireTime + fireInterval)
                {
                    //onAttackEvent.Call(new TargetAttackData(1000, playerCamera.transform.forward));
                    Shot();
                    lastFireTime = Time.time;
                    shooting = false;
                }
                if (shooting)
                {
                    EndFire();
                    shooting = false;
                }
            }
            else
            {
                if (shooting && Time.time > lastFireTime + fireInterval)
                {
                    Shot();
                    lastFireTime = Time.time;
                    shooting = false;
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                isAiming = true;
            }
            if (Input.GetMouseButtonUp(1))
            {
                isAiming = false;
            }

            currentFov = Mathf.Lerp(currentFov, isAiming ? AimFov : DefaultFov, Time.deltaTime * 12f);
        }

        protected virtual void EndFire()
        {

        }

        protected virtual void Shot()
        {
            handsAnimator.Play("Shot", 0, 0);
            Ray r = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
            RaycastHit hitInfo;

            if (Physics.Raycast(r, out hitInfo, 1000, ShotMask, QueryTriggerInteraction.Ignore))
            {

                var hittable = hitInfo.collider.GetComponent<IHittable>();
                if (hittable != null)
                {
                    DamageData[] damage = new DamageData[1]
                    {
                    new DamageData()
                    {
                        amount = Damage,
                        direction = r.direction,
                        normal = hitInfo.normal,
                        point = hitInfo.point
                    }
                    };

                    hittable.TakeDamage(damage);
                }
            }
            StartCoroutine(cameraShake.Shake(shakeDuration, shakeMagnitude));

            DebugShot(r, hitInfo);
        }

        protected void DebugShot(Ray r, RaycastHit hitInfo)
        {
            if (hitInfo.collider != null)
            {
                Debug.DrawLine(r.origin, hitInfo.point, Color.green, 3f);
            }
            else
            {
                Debug.DrawLine(r.origin, r.GetPoint(1000), Color.red, 3f);
            }
        }

        public Vector3 GetLookDirection()
        {
            return playerCamera.transform.forward;
        }
    }
}