using UnityEngine;

public class RandomColorChanger : MonoBehaviour
{
    // Rango de colores que se aplicará al albedo del material
    [SerializeField] private Color minColor = Color.white;
    [SerializeField] private Color maxColor = Color.black;

    // Material del enemigo
    private Material enemyMaterial;

    void Start()
    {
        // Obtener el material del objeto enemigo
        enemyMaterial = GetComponent<Renderer>().material;

        // Aplicar un color aleatorio al material
        ApplyRandomColor();
    }

    private void ApplyRandomColor()
    {
        // Generar un color aleatorio entre el rango definido
        Color randomColor = new Color(
            Random.Range(minColor.r, maxColor.r),
            Random.Range(minColor.g, maxColor.g),
            Random.Range(minColor.b, maxColor.b),
            1.0f // Mantener el alfa en 1
        );

        // Aplicar el color al albedo del material
        enemyMaterial.SetColor("_Color", randomColor);
    }
}
