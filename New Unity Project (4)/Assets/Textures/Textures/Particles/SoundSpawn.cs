using UnityEngine;

namespace AsteroidBashers
{
    public class PolygonSoundSpawn : MonoBehaviour
    {
        public GameObject prefabSound;

        public bool destroyWhenDone = true;
        public bool soundPrefabIsChild = false;
        [Range(0.01f, 10f)]
        public float pitchRandomMultiplier = 1f;

        void Start()
        {
            GameObject m_Sound = Instantiate(prefabSound, transform.position, Quaternion.identity);
            AudioSource m_Source = m_Sound.GetComponent<AudioSource>();

            if (soundPrefabIsChild)
                m_Sound.transform.SetParent(transform);

            if (pitchRandomMultiplier != 1)
            {
                if (Random.value < .5)
                    m_Source.pitch *= Random.Range(1 / pitchRandomMultiplier, 1);
                else
                    m_Source.pitch *= Random.Range(1, pitchRandomMultiplier);
            }

            if (destroyWhenDone)
            {
                float life = m_Source.clip.length / m_Source.pitch;
                Destroy(m_Sound, life);
            }
        }
    }
}
