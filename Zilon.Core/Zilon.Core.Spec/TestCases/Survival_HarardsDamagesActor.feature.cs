﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.4.0.0
//      SpecFlow Generator Version:2.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Zilon.Core.Spec.TestCases
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("Survival_HarardsDamagesActor", Description="\tЧтобы была необходимость своевременно пополнять характеристики выживания\r\n\tКак и" +
        "гроку\r\n\tМне нужно, чтобы актёр, находящийся под максимальной угрозой выживания т" +
        "ерял здоровье.", SourceFile="TestCases\\Survival_HarardsDamagesActor.feature", SourceLine=0)]
    public partial class Survival_HarardsDamagesActorFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Survival_HarardsDamagesActor.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Survival_HarardsDamagesActor", "\tЧтобы была необходимость своевременно пополнять характеристики выживания\r\n\tКак и" +
                    "гроку\r\n\tМне нужно, чтобы актёр, находящийся под максимальной угрозой выживания т" +
                    "ерял здоровье.", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [TechTalk.SpecRun.FeatureCleanup()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        [TechTalk.SpecRun.ScenarioCleanup()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void ЭффектыУгрозВыживанияНаносятУронАктёру_(string startEffect, string moveDistance, string expectedHpValue, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "survival",
                    "dev0"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Эффекты угроз выживания наносят урон актёру.", null, @__tags);
#line 7
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 8
 testRunner.Given("Есть карта размером 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.And("Есть актёр игрока класса captain в ячейке (0, 0)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.And(string.Format("Актёр имеет эффект {0}", startEffect), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.When(string.Format("Я перемещаю персонажа на {0} клетку", moveDistance), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.Then(string.Format("Актёр игрока имеет запас hp {0}", expectedHpValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Эффекты угроз выживания наносят урон актёру., Голодание", new string[] {
                "survival",
                "dev0"}, SourceLine=15)]
        public virtual void ЭффектыУгрозВыживанияНаносятУронАктёру__Голодание()
        {
#line 7
this.ЭффектыУгрозВыживанияНаносятУронАктёру_("Голодание", "1", "115", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Эффекты угроз выживания наносят урон актёру., Обезвоживание", new string[] {
                "survival",
                "dev0"}, SourceLine=15)]
        public virtual void ЭффектыУгрозВыживанияНаносятУронАктёру__Обезвоживание()
        {
#line 7
this.ЭффектыУгрозВыживанияНаносятУронАктёру_("Обезвоживание", "1", "115", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Эффекты угроз выживания наносят урон актёру., Слабый голод", new string[] {
                "survival",
                "dev0"}, SourceLine=15)]
        public virtual void ЭффектыУгрозВыживанияНаносятУронАктёру__СлабыйГолод()
        {
#line 7
this.ЭффектыУгрозВыживанияНаносятУронАктёру_("Слабый голод", "1", "120", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Эффекты угроз выживания наносят урон актёру., Голод", new string[] {
                "survival",
                "dev0"}, SourceLine=15)]
        public virtual void ЭффектыУгрозВыживанияНаносятУронАктёру__Голод()
        {
#line 7
this.ЭффектыУгрозВыживанияНаносятУронАктёру_("Голод", "1", "120", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Эффекты угроз выживания наносят урон актёру., Слабая жажда", new string[] {
                "survival",
                "dev0"}, SourceLine=15)]
        public virtual void ЭффектыУгрозВыживанияНаносятУронАктёру__СлабаяЖажда()
        {
#line 7
this.ЭффектыУгрозВыживанияНаносятУронАктёру_("Слабая жажда", "1", "120", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Эффекты угроз выживания наносят урон актёру., Жажда", new string[] {
                "survival",
                "dev0"}, SourceLine=15)]
        public virtual void ЭффектыУгрозВыживанияНаносятУронАктёру__Жажда()
        {
#line 7
this.ЭффектыУгрозВыживанияНаносятУронАктёру_("Жажда", "1", "120", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.TestRunCleanup()]
        public virtual void TestRunCleanup()
        {
            TechTalk.SpecFlow.TestRunnerManager.GetTestRunner().OnTestRunEnd();
        }
    }
}
#pragma warning restore
#endregion
