using UnityEngine;

namespace SoundManagerAPI
{
    public class MinMaxSliderAttribute : PropertyAttribute
    {
        public float minValue;
        public float maxValue;

        public MinMaxSliderAttribute(float minValue, float maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }
    }
}