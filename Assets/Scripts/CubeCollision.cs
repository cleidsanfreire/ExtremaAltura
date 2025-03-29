using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    [SerializeField] private AudioSource audioSourceCubeCollision;
    bool firstCollisionCube;

    public void OnCollisionEnter(Collision collision)
    {
        audioSourceCubeCollision.PlayOneShot(audioSourceCubeCollision.clip);

        if (!firstCollisionCube)
        {
            firstCollisionCube = true;
            Invoke(nameof(DesativeAudio), 5);
        }
    }

    private void DesativeAudio()
    {
        enabled = false;
    }
}
