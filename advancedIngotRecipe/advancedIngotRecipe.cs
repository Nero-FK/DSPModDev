using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using xiaoye97;
namespace advancedIngotRecipe
{
    [BepInDependency("me.xiaoye97.plugin.Dyson.LDBTool", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin(ModGuid, ModName, ModVersion)]

    public class advancedIngotRecipe : BaseUnityPlugin
    {
        private Sprite copperIcon;
        private Sprite ironIcon;
        private Sprite siliconIcon;
        private Sprite titaniumIcon;
        //テスト

        public const string ModGuid = "jp.co.nero.dsp.advancedIngotRecipe";
        public const string ModName = "advancedIngotRecipe";
        public const string ModVersion = "1.0.0";

        new internal static ManualLogSource Logger;

        private RecipeProto orgRecipe;

        public void Awake()
        {
            Logger = base.Logger;
        }

        public void Start()
        {
            var assetBundle = AssetBundle.LoadFromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("advancedIngotRecipe.advancedcopper"));
            this.copperIcon = assetBundle.LoadAsset<Sprite>("advancedCopper");
            assetBundle = AssetBundle.LoadFromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("advancedIngotRecipe.advancediron"));
            this.ironIcon = assetBundle.LoadAsset<Sprite>("advancedIron");
            assetBundle = AssetBundle.LoadFromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("advancedIngotRecipe.advancedsilicon"));
            this.siliconIcon = assetBundle.LoadAsset<Sprite>("advancedSilicon");
            assetBundle = AssetBundle.LoadFromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("advancedIngotRecipe.advancedtitanium"));
            this.titaniumIcon = assetBundle.LoadAsset<Sprite>("advancedTitanium");

            recipeSetup();

            LDBTool.PreAddDataAction += this.AddAdvancedIron;
            LDBTool.PreAddDataAction += this.AddAdvancedCopper;
            LDBTool.PreAddDataAction += this.AddAdvancedSilicon;
            LDBTool.PreAddDataAction += this.AddAdvancedTitanium;
            LDBTool.PreAddDataAction += this.AddLang;
        }

        private void recipeSetup()
        {
            orgRecipe = LDB.recipes.Select(58);
        }

        private void AddAdvancedIron()
        {
            Logger.LogInfo("AddAdvancedIron Start");
            RecipeProto advIron = orgRecipe.Copy();
            advIron.ID = 620;
            advIron.Name = "铁锭（高效）";
            advIron.name = advIron.Name.Translate();
            advIron.Description = "您可以通过加水生成更多的铸锭。";
            advIron.description = advIron.Description.Translate();
            advIron.Items = new int[] { 1001, 1000 };
            advIron.ItemCounts = new int[] { 6, 4 };
            advIron.Results = new int[] { 1101 };
            advIron.ResultCounts = new int[] { 15 };
            advIron.Explicit = true;
            advIron.TimeSpend = (60 * 12);
            advIron.GridIndex = 1708;
            advIron.SID = advIron.GridIndex.ToString();
            advIron.sid = advIron.GridIndex.ToString().Translate();
            Traverse.Create(advIron).Field("_iconSprite").SetValue(this.ironIcon);
            var ironIngotItem = LDB.items.Select(1101);
            ironIngotItem.recipes.Add(advIron);
            LDBTool.PostAddProto(ProtoType.Recipe, advIron);
            Logger.LogInfo("AddAdvancedIron End");
        }

        private void AddAdvancedCopper()
        {
            Logger.LogInfo("AddAdvancedCopper Start");
            RecipeProto advCopper = orgRecipe.Copy();
            advCopper.ID = 621;
            advCopper.Name = "铜锭（高效）";
            advCopper.name = advCopper.Name.Translate();
            advCopper.Description = "您可以通过加水生成更多的铸锭。";
            advCopper.description = advCopper.Description.Translate();
            advCopper.Items = new int[] { 1002, 1000 };
            advCopper.ItemCounts = new int[] { 6, 4 };
            advCopper.Results = new int[] { 1104 };
            advCopper.ResultCounts = new int[] { 15 };
            advCopper.Explicit = true;
            advCopper.TimeSpend = (60 * 12);
            advCopper.GridIndex = 1709;
            advCopper.SID = advCopper.GridIndex.ToString();
            advCopper.sid = advCopper.GridIndex.ToString().Translate();
            Traverse.Create(advCopper).Field("_iconSprite").SetValue(this.copperIcon);
            var copperIngotItem = LDB.items.Select(1104);
            copperIngotItem.recipes.Add(advCopper);
            LDBTool.PostAddProto(ProtoType.Recipe, advCopper);
            Logger.LogInfo("AddAdvancedCopper End");
        }

        private void AddAdvancedSilicon()
        {
            Logger.LogInfo("AddAdvancedSilicon Start");
            RecipeProto advSilicon = orgRecipe.Copy();
            advSilicon.ID = 622;
            advSilicon.Name = "高纯度硅（高效）";
            advSilicon.name = advSilicon.Name.Translate();
            advSilicon.Description = "您可以通过加水生成更多的铸锭。";
            advSilicon.description = advSilicon.Description.Translate();
            advSilicon.Items = new int[] { 1003, 1000 };
            advSilicon.ItemCounts = new int[] { 6, 4 };
            advSilicon.Results = new int[] { 1105 };
            advSilicon.ResultCounts = new int[] { 15 };
            advSilicon.Explicit = true;
            advSilicon.TimeSpend = (60 * 12);
            advSilicon.GridIndex = 1710;
            advSilicon.SID = advSilicon.GridIndex.ToString();
            advSilicon.sid = advSilicon.GridIndex.ToString().Translate();
            Traverse.Create(advSilicon).Field("_iconSprite").SetValue(this.siliconIcon);
            var siliconIngotItem = LDB.items.Select(1105);
            siliconIngotItem.recipes.Add(advSilicon);
            LDBTool.PostAddProto(ProtoType.Recipe, advSilicon);
            Logger.LogInfo("AddAdvancedSilicon End");
        }

        private void AddAdvancedTitanium()
        {
            Logger.LogInfo("AddAdvancedTitanium Start");
            RecipeProto advTitan = orgRecipe.Copy();
            advTitan.ID = 623;
            advTitan.Name = "钛锭（高效）";
            advTitan.name = advTitan.Name.Translate();
            advTitan.Description = "您可以通过加水生成更多的铸锭。";
            advTitan.description = advTitan.Description.Translate();
            advTitan.Items = new int[] { 1004, 1000 };
            advTitan.ItemCounts = new int[] { 6, 4 };
            advTitan.Results = new int[] { 1106 };
            advTitan.ResultCounts = new int[] { 15 };
            advTitan.Explicit = true;
            advTitan.TimeSpend = (60 * 12);
            advTitan.GridIndex = 1711;
            advTitan.SID = advTitan.GridIndex.ToString();
            advTitan.sid = advTitan.GridIndex.ToString().Translate();
            Traverse.Create(advTitan).Field("_iconSprite").SetValue(this.titaniumIcon);
            var titanIngotItem = LDB.items.Select(1106);
            titanIngotItem.recipes.Add(advTitan);
            LDBTool.PostAddProto(ProtoType.Recipe, advTitan);
            Logger.LogInfo("AddAdvancedTitanium End");
        }

        private void AddLang()
        {
            Logger.LogInfo("AddLang Start");
            int stringid = 53001;
            // iron item
            setStringProto(new StringProto(), stringid, "铁锭（高效）", "Iron Ingot (efficient)");
            // copper item
            setStringProto(new StringProto(), stringid++, "铜锭（高效）", "Copper Ingoto (efficient)");
            // silicon item
            setStringProto(new StringProto(), stringid++, "高纯度硅（高效）", "High-purity silicon (efficient)");
            // titan item
            setStringProto(new StringProto(), stringid++, "钛锭（高效）", "Titanium ingot (efficient)");

            string descCN = "您可以通过加水生成更多的铸锭。";
            string descEN = "You can generate more ingots by adding water.";
            // iron desc
            setStringProto(new StringProto(), stringid++, descCN, descEN);
            // copper desc
            //setStringProto(new StringProto(), stringid++, descCN, descEN);
            // silicon desc
            //setStringProto(new StringProto(), stringid++, descCN, descEN);
            // titan desc
            //setStringProto(new StringProto(), stringid++, descCN, descEN);
            Logger.LogInfo("AddLang End");
        }

        private void setStringProto(StringProto proto, int id, String strCN, String strEN)
        {
            proto.ID = id;
            proto.Name = strCN;
            proto.name = strCN;
            proto.ZHCN = strCN;
            proto.ENUS = strEN;
            proto.FRFR = strEN;
            LDBTool.PreAddProto(ProtoType.String, proto);
        }
    }
}
