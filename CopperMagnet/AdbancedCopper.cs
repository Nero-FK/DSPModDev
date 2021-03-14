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

namespace AdbancedCopper
{
    [BepInDependency("me.xiaoye97.plugin.Dyson.LDBTool", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin(ModGuid, ModName, ModVersion)]
    public class AdbancedCopper : BaseUnityPlugin
    {
        private Sprite icon;

        public const string ModGuid = "jp.co.nero.dsp.adbancedcopper";
        public const string ModName = "AdbancedCopper";
        public const string ModVersion = "1.0.0";

        new internal static ManualLogSource Logger;

        public void Awake()
        {
            Logger = base.Logger;
        }
       void Start()
        {
            //var ab = AssetBundle.LoadFromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("AdbancedCopper.copper-adbanced.png"));
            //this.icon = ab.LoadAsset<Sprite>("copper-adbanced.png");
            LDBTool.PreAddDataAction += this.AddAdbancedCopper;
            LDBTool.PreAddDataAction += this.AddLang;
        }

        // レシピ追加
        private void AddAdbancedCopper()
        {
            Logger.LogInfo("AddAdbancedCopperStart");
            RecipeProto XRayRecipeOrg = LDB.recipes.Select(58);
            RecipeProto copperIngotNew = XRayRecipeOrg.Copy();
            // レシピid
            copperIngotNew.ID = 610;
            // レシピ名
            copperIngotNew.Name = "铜锭（高效）";
            copperIngotNew.name = copperIngotNew.Name.Translate();
            // レシピの説明
            copperIngotNew.Description = "您可以通过加水生成更多的铸锭。";
            copperIngotNew.description = copperIngotNew.Description.Translate();
            // アイテムを作成する施設
            //copperIngotNew.Type = ERecipeType.Refine;
            // 要求アイテムid
            copperIngotNew.Items = new int[] { 1002, 1000 };
            // 作成アイテムid
            copperIngotNew.Results = new int[] { 1104 };
            // 要求アイテム個数
            copperIngotNew.ItemCounts = new int[] { 6, 4 };
            // 作成アイテム個数
            copperIngotNew.ResultCounts = new int[] { 15 };
            // ?
            copperIngotNew.Explicit = true;
            // 手制作の可否
            //copperIngotNew.Handcraft = false;
            // 利用するための前提研究
            //copperIngotNew.preTech = LDB.techs.Select(1702);
            // 作成時間
            copperIngotNew.TimeSpend = (60 * 12);
            // レシピのインデックス
            Logger.LogInfo($"Setting: copperIngotoNew.GridIndexOld : { copperIngotNew.GridIndex }");
            copperIngotNew.GridIndex = 1112;
            Logger.LogInfo($"Setting: copperIngotoNew.GridIndexNew : { copperIngotNew.GridIndex }");
            copperIngotNew.SID = "1112";
            copperIngotNew.sid = "1112".Translate();
            copperIngotNew.IconPath = "Icons/ItemRecipe/nanotube-lv2";
            RecipeProto recipeProto3 = LDB.recipes.Select(23);
            //Traverse.Create(copperIngotNew).Field("_iconSprite").SetValue(recipeProto3.iconSprite);
            var copperIngotItem = LDB.items.Select(1104);
            copperIngotItem.recipes.Add(copperIngotNew);
            LDBTool.PostAddProto(ProtoType.Recipe, copperIngotNew);
            Logger.LogInfo($"Setting: copperIngotoNew.GridIndex : { copperIngotNew.GridIndex }");
            Logger.LogInfo($"Setting: copperIngotoNew.SID : { copperIngotNew.SID }");
            Logger.LogInfo($"Setting: copperIngotoNew.sid : { copperIngotNew.sid }");
            Logger.LogInfo($"Setting: copperIngotoNew.IconPath : { copperIngotNew.IconPath }");
            Logger.LogInfo("AddAdbancedCopperEnd");
        }

        // アイテム名とアイテム説明
        private void AddLang()
        {
            StringProto stringProto = new StringProto();
            StringProto stringProto2 = new StringProto();
            stringProto.ID = 53001;
            stringProto.Name = "铜锭（高效）";
            stringProto.name = "铜锭（高效）";
            stringProto.ZHCN = "铜锭（高效）";
            stringProto.ENUS = "Copper Ingoto (high efficiency)";
            stringProto2.ID = 53002;
            stringProto2.Name = "您可以通过加水生成更多的铸锭。";
            stringProto2.name = "您可以通过加水生成更多的铸锭。";
            stringProto2.ZHCN = "您可以通过加水生成更多的铸锭。";
            stringProto2.ENUS = "You can generate more ingots by adding water.";
            LDBTool.PreAddProto(ProtoType.String, stringProto);
            LDBTool.PreAddProto(ProtoType.String, stringProto2);
        }
    }
}
