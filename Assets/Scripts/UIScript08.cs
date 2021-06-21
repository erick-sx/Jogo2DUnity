using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript08 : MonoBehaviour
{
    public GameObject[] questionGroupArray;
    public QAClass08[] qaArray;
    public GameObject AnswerPanelPT;

    // Start is called before the first frame update
    void Start()
    {
        qaArray = new QAClass08[questionGroupArray.Length];
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SubmitAnswer()
    {
        for(int i = 0; i < qaArray.Length; i++)
        {
            qaArray[i] = ReadQuestionAndAnswer(questionGroupArray[i]);
        }
        DisplayResult();
    }

    public void Finalizar()
    {
         
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    QAClass08 ReadQuestionAndAnswer(GameObject questionGroup)
    {
        QAClass08 result = new QAClass08();

        GameObject q = questionGroup.transform.Find("Question").gameObject;
        GameObject a = questionGroup.transform.Find("Answer").gameObject;

        result.Question = q.GetComponent<Text>().text;

        if (a.GetComponent<ToggleGroup>() != null)
        {
            for (int i = 0; i < a.transform.childCount; i++)
            {
                if (a.transform.GetChild(i).GetComponent<Toggle>().isOn)
                {
                    result.Answer = a.transform.GetChild(i).
                    Find("Label").GetComponent<Text>().text;
                    break;
                }
            }
        }

        else if (a.GetComponent<InputField>() != null)
        {
            result.Answer = a.transform.Find("Text").GetComponent<Text>().text;
        }

        else if (a.GetComponent<ToggleGroup>() == null && a.GetComponent<InputField>() == null)
        {
            string s = "";
            int counter = 0;

            for (int i = 0; i < a.transform.childCount; i++)
            {
                if (a.transform.GetChild(i).GetComponent<Toggle>().isOn)
                {
                    if (counter != 0)
                    {
                        s = s + ", ";
                    }

                    s = s + a.transform.GetChild(i).Find("Label").GetComponent<Text>().text;

                    counter++;
                }

                if (i == a.transform.childCount - 1)
                {
                    s = s + ".";
                }
            }

            result.Answer = s;
        }

        return result;
    }

    void DisplayResult()
    {
        AnswerPanelPT.SetActive(true);

        string s = "";

        for (int i = 0; i < qaArray.Length; i++)
        {
            if(i == 0){
            s = s + qaArray[i].Question + "\n(A resposta correta é: Da escolha entre viver em segurança ou em perigo.)\n Você respondeu:\n";
            s = s + qaArray[i].Answer + "\n\n";
            }
            if(i == 1){
            s = s + qaArray[i].Question + "\n(A resposta correta é: O ratinho da cidade e o ratinho do campo.)\n Você respondeu:\n";
            s = s + qaArray[i].Answer + "\n\n";
            }
            if(i == 2){
            s = s + qaArray[i].Question + "\n";
            s = s + qaArray[i].Answer + "\n";
            }
        }

       AnswerPanelPT.transform.Find("Text").GetComponent<Text>().text = s;


    }
}

[System.Serializable]
public class QAClass08
{
    public string Question = "";
    public string Answer = "";

}