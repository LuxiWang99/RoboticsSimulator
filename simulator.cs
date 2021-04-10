using UnityEditor;
using System.Diagnostics;
using System;
using System.IO;

public class ScriptBatch 
{

   [ComVisible(true)]
   public static void testing()
   {
     Console.WriteLine("This is from C#");
   }




    [MenuItem("MyTools/Windows Build With Postprocess")]
    public static void BuildGame ()
    {
        // Get filename.
        string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string[] levels = new string[] {"Assets/MainScene.unity", "Assets/MissionControl.unity"};

        // Build player.
        BuildPipeline.BuildPlayer(levels, path + "/simulator.app", BuildTarget.StandaloneWindows, BuildOptions.None);

        //// Copy a file from the project folder to the build folder, alongside the built game.
        //FileUtil.CopyFileOrDirectory("Assets/Templates/Readme.txt", path + "Readme.txt");

        // Run the game (Process class from System.Diagnostics).
        Process proc = new Process();
        proc.StartInfo.FileName = path + "/simulator.app";
        proc.Start();
    }
}
