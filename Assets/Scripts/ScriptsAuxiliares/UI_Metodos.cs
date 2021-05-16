using UnityEngine.SceneManagement;

public static class UI_Metodo
{
    //Evento de click do btn "Voltar" das cenas loja, Galeria e Levels
    public static void Voltar()
    {
        if (LevelAtual.instance.level > 0)
        {
            if (LevelAtual.instance.level == 2)
            {
                SceneManager.LoadScene(LevelAtual.instance.level - 1);
            }
            else if (LevelAtual.instance.level == 3)
            {
                SceneManager.LoadScene(LevelAtual.instance.level - 2);
            }
            else if (LevelAtual.instance.level == 4)
            {
                SceneManager.LoadScene(LevelAtual.instance.level - 3);
            }
            else if (LevelAtual.instance.level == 5)
            {
                SceneManager.LoadScene(LevelAtual.instance.level - 4);
            }
        }
    }
    //Evento de clicks dos btns "Loja", Galeria e FaseMestra
    public static void CarregaCena(string cena)
    {
        SceneManager.LoadScene(cena);
    }
    //testando****
    //public static void Voltar_P_WL(string cena)
    //{
    //    SceneManager.LoadScene(cena);
    //}
}
