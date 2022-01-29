using UnityEngine;
using UnityEngine.Events;

namespace SDA.Generation
{
    public class SimpleShield : BaseShield
    {
        private float currentNormalizedTime; //percent
        private float duration;
        private float startTime;
        private Vector3 startAngle;
        private Vector3 endAngle;

        private int currentStep;

        public override void Initialize(UnityAction onKnifeShieldHit,
            UnityAction onWinCallback)
        {
            base.Initialize(onKnifeShieldHit, onWinCallback);
            
            currentStep = 0;
            var currentStepData = movementScheme[currentStep];
            
            startTime = Time.time;
            duration = currentStepData.time;
            currentNormalizedTime = 0f;
            startAngle = transform.rotation.eulerAngles;
            endAngle = startAngle + Vector3.forward * currentStepData.angle;
            //Vector3.Forward = new Vector3(0,0,1)
        }

        public override void Rotate()
        {
            currentNormalizedTime = (Time.time - startTime) / duration;
            if (currentNormalizedTime >= 1f)
            {
                currentStep++;
                if (currentStep == movementScheme.Length)
                    currentStep = 0;
                
                var currentStepData = movementScheme[currentStep];
                
                startTime = Time.time;
                duration = currentStepData.time;
                currentNormalizedTime = 0f;
                startAngle = transform.rotation.eulerAngles;
                endAngle = startAngle + Vector3.forward * currentStepData.angle;
            }

            var finalAngle = Vector3.Lerp(startAngle, endAngle, currentNormalizedTime);
            transform.rotation = Quaternion.Euler(finalAngle);
        }
    }
}