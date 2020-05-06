using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRUA_my : MonoBehaviour
{
    Vector3 aceleracao;
    public Vector3 deslocamento;
    public Vector3 velocidade;
    float tempo;
    public float massa = 1;
    public Vector3 forca;
    Vector3 gravidade = new Vector3(0, -9.8f, 0);
    public float elasticidade;
    // Start is called before the first frame update
    void Start()
    {
        deslocamento = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float tempo = Time.fixedDeltaTime;
        aceleracao = forca / massa + gravidade;
        velocidade += aceleracao * tempo;
        deslocamento += tempo * velocidade;
        transform.position = deslocamento;
        forca = Vector3.zero;

        if (deslocamento.y < 0.5f)
        {
            velocidade = velocidade.magnitude * elasticidade *
                    Refletir(velocidade.normalized, Vector3.up);
            deslocamento.y = 0.5f;
        }

        if (velocidade.magnitude > 0.1f)
            transform.position = deslocamento;
    }
    public void AddForce(Vector3 f)
    {
        forca = f;
    }
    public static Vector3 Refletir(Vector3 vector, Vector3 normal)
    {
        return vector - 2 * Vector3.Dot(vector, normal) * normal;
    }
}
