using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GeneratorCube : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    private GameObject lastCubeGenerator;

    private HeightConstruction heightConstruction;

    private Transform myCamera;

    private Vector3 moviment;

    [SerializeField] UnityEvent OnReleaseCube;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myCamera = Camera.main.transform;
        heightConstruction = GetComponent<HeightConstruction>();
        CubeGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        if (lastCubeGenerator == null) return;

        //Vector3 moviment = new Vector3(Input.GetAxis("Horizontal"),0f , Input.GetAxis("Vertical"));

        Vector3 directionCamera = myCamera.TransformDirection(moviment);
        directionCamera.y = 0f;
            
        lastCubeGenerator.transform.position += directionCamera.normalized * Time.deltaTime * 3f;
    }

    public void CubeGenerator() 
    {
        float randomPosition = Random.Range(-3f, 3f);

        lastCubeGenerator = Instantiate(cubePrefab, new Vector3(randomPosition, heightConstruction.HeightCurrent() + 2, randomPosition), Quaternion.identity);

        float widthX = Random.Range(1, 7);
        float widthY = Random.Range(1, 5);
        float widthZ = Random.Range(1, 7);

        lastCubeGenerator.transform.localScale = new Vector3(widthX, widthY, widthZ);
        lastCubeGenerator.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();

    }

    public void ReleaseCube()
    {
        lastCubeGenerator.GetComponent<Rigidbody>().useGravity = true;
        lastCubeGenerator.transform.GetChild(0).gameObject.SetActive(false);
        lastCubeGenerator = null;

        OnReleaseCube.Invoke();

        Invoke(nameof(CubeGenerator), 2);
    }

    public void MoverCubo(InputAction.CallbackContext value)
    {
        Vector2 move = value.ReadValue<Vector2>();
        moviment = new Vector3(move.x, 0f, move.y);
    }


    public void ReleaseCube(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            ReleaseCube();
        }
    }
}
