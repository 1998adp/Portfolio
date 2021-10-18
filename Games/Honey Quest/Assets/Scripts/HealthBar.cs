using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Honey honey;
    [HideInInspector]
    public CanBePickedUp character;
    public Image honey1;
    public Image honey2;
    public Image honey3;
    public Image honey4;

    int maxHoney;
    // Start is called before the first frame update
    void Start()
    {
        maxHoney = character.maxHoney;
    }

    // Update is called once per frame
    void Update()
    {
        if(character != null)
        {
            switch(honey.value)
            {
                case 0:
                {
                    honey1.fillAmount = 0;
                    honey2.fillAmount = 0;
                    honey3.fillAmount = 0;
                    honey4.fillAmount = 0;
                    break;
                }
                case 1:
                {
                    honey1.fillAmount = 1;
                    honey2.fillAmount = 0;
                    honey3.fillAmount = 0;
                    honey4.fillAmount = 0;
                        break;
                }
                case 2:
                {
                    honey1.fillAmount = 1;
                    honey2.fillAmount = 1;
                    honey3.fillAmount = 0;
                    honey4.fillAmount = 0;
                        break;
                }
                case 3:
                {
                    honey1.fillAmount = 1;
                    honey2.fillAmount = 1;
                    honey3.fillAmount = 1;
                    honey4.fillAmount = 0;
                        break;
                }
                case 4:
                {
                    honey1.fillAmount = 1;
                    honey2.fillAmount = 1;
                    honey3.fillAmount = 1;
                    honey4.fillAmount = 1;
                        break;
                }

            }
        }
    }
}
