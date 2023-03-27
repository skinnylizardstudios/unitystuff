using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[Version(1, 0, 0)]

[Title("Modify Image Material Float")]
[Category("UI/Modify Image Material Float")]

[Image(typeof(IconUIImage), ColorTheme.Type.TextLight)]
[Description("Modify the Material of an Image component")]

[Parameter("Image", "Refer to the image whose material you want to modify")]
[Parameter("Parameter", "The name of the parameter to be modified in the material")]
[Parameter("Value", "Modified value")]
public class InstructionModifyImageMaterialFloat : Instruction
{
    [SerializeField] private PropertyGetGameObject m_Image = GetGameObjectInstance.Create();
    [SerializeField] private PropertyGetString m_Parameter = new PropertyGetString();
    [SerializeField] private PropertyGetDecimal m_Value = new PropertyGetDecimal();
    protected override Task Run(Args args)
    {
        GameObject gameObject = this.m_Image.Get(args);
        if (gameObject == null) return DefaultResult;

        Image image = gameObject.Get<Image>();
        if (image == null) return DefaultResult;
        if (image.material == null) return DefaultResult;
        image.material.SetFloat(this.m_Parameter.Get(args), (float)this.m_Value.Get(args));

        return DefaultResult;
    }
}
