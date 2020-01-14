using UnityEngine;

namespace AsteroidBashers
{
    public class LightFlicker : MonoBehaviour
    {
        public string waveFunction = "sin";
        public float startValue = 0.0f;
        public float amplitude = 1.0f;
        public float phase = 0.0f;
        public float frequency = 0.5f;

        private Color originalColor;

        void Start()
        {
            originalColor = GetComponent<Light>().color;
        }

        void Update()
        {
            Light light = GetComponent<Light>();
            light.color = originalColor * (EvalWave());
        }

        float EvalWave()
        {
            float x = (Time.time + phase) * frequency;
            float y;

            x = x - Mathf.Floor(x);

            if (waveFunction == "sin")
            {
                y = Mathf.Sin(x * 2 * Mathf.PI);
            }
            else if (waveFunction == "tri")
            {
                if (x < 0.5f)
                    y = 4.0f * x - 1.0f;
                else
                    y = -4.0f * x + 3.0f;
            }
            else if (waveFunction == "sqr")
            {
                if (x < 0.5f)
                    y = 1.0f;
                else
                    y = -1.0f;
            }
            else if (waveFunction == "saw")
            {
                y = x;
            }
            else if (waveFunction == "inv")
            {
                y = 1.0f - x;
            }
            else if (waveFunction == "noise")
            {
                y = 1 - (Random.value * 2);
            }
            else
            {
                y = 1.0f;
            }
            return (y * amplitude) + startValue;
        }
    }
}