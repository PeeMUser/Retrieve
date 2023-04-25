using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    public HPSystem hp;
    public Image fillImage;
    private Slider slider;


    
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        DontDestroyOnLoad(this);

    }

    // Update is called once per frame
    void Update()
    {
        
        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }
        if (slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }
        float fillValue = hp.currentHealth / hp.maxHealth;
        if (fillValue <= slider.maxValue / 4)
        {
            fillImage.color = Color.red;
        }
       
        slider.value = fillValue;
    }
}
