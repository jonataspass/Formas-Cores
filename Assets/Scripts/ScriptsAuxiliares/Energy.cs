using UnityEngine;

//pensar em desativar********
//aumentar o nivel de energia
public class Energy : MonoBehaviour
{
    public static Energy energY;
    public CircleManager circleManager;

    public int y;
    
    private void Start()
    {
        circleManager = GameObject.FindWithTag("circleManager").GetComponent<CircleManager>();
        MaxEnergy();
    }

    public void AtualizaEnergy(int indexVetCircles)
    {       
        y = circleManager.circles[indexVetCircles].currentlife + 1;
        
        if (y >= 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, y, transform.localScale.z);
        }
    }

    //Define o tamanho máximo da barra de energia
    void MaxEnergy()
    {
        for (int i = 0; i < circleManager.circles.Length; i++)
        {
            circleManager.circles[i].maxLife = circleManager.maxEnergy;
        }
    }

}
