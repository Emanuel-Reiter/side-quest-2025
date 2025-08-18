using TMPro;
using UnityEngine;

public class PlayerKeys : MonoBehaviour
{
    public bool key_01 = false;
    public bool key_02 = false;
    public bool key_03 = false;
    public bool key_04 = false;

    public int generatorsOn = 0;
    public TMP_Text generatorText;

    public void TurnOnGenerator()
    {
        generatorsOn++;
        generatorText.text = $"Geradores ativos {generatorsOn}/3";
    }

}
