using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;



[Version(1, 0, 0)]

[Title("Change Active Scene")]
[Description("Change the active scene, useful for those that are making their game using multiple scenes")]
[Category("Scenes/Change Active Scene")]
[Parameter("Scene", "Scene to be set as active")]
[Keywords("Scene", "Active", "Change")]

[Image(typeof(IconUnity), ColorTheme.Type.TextNormal)]
[Serializable]
public class InstructionChangeActiveScene : Instruction
{

    // MEMBERS: -------------------------------------------------------------------------------
    [SerializeField] private PropertyGetScene m_Scene;
    // PROPERTIES: ----------------------------------------------------------------------------
    public override string Title => string.Format(
        "Set {0} as Active Scene",
        this.m_Scene
    );
    // RUN METHOD: ----------------------------------------------------------------------------
    protected override Task Run(Args args)
    {
        var scene = this.m_Scene.Get(args);

        if (SceneManager.GetSceneByBuildIndex(scene).isLoaded == false) return null;
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(scene));
        
        return DefaultResult;
    }
}
