using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Test1 : MonoBehaviour
{
    public InputField inputField;
    public Text resultText;
    //public string income;

    public List<string> nameOfBrandList = new List<string>();

    public void Start()
    {
        string nameOfBrand_1 = "Sony";
        nameOfBrandList.Add(nameOfBrand_1);
        string nameOfBrand_2 = "Xiaomi";
        nameOfBrandList.Add(nameOfBrand_2);
        string nameOfBrand_3 = "Unreal";
        nameOfBrandList.Add(nameOfBrand_3);
        string nameOfBrand_4 = "Unity";
        nameOfBrandList.Add(nameOfBrand_4);
        string nameOfBrand_5 = "Apple";
        nameOfBrandList.Add(nameOfBrand_5);
        string nameOfBrand_6 = "Samsung";
        nameOfBrandList.Add(nameOfBrand_6);





    }
    public void OnFind()
    {


        if (nameOfBrandList.Contains(inputField.text))
        {
            resultText.text = "[" + inputField.text + "]" + "Has found";
        }
        else
        {
            resultText.text = "has not found";
        }


    }
}
