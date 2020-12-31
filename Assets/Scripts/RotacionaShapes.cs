using UnityEngine;

//Script add a todas shapes que podem ser clicadas
public class RotacionaShapes : MonoBehaviour
{
    //Circle de entrada
    public string nomeCircle;

    //Variável de entrada para o prefab CirclesRotManager
    public CirclesRotation circlesRot;

    private void OnMouseDown()
    {
        circlesRot.RotacionaAllCircles(nomeCircle);    
    }
}
