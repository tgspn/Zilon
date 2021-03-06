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
    [TechTalk.SpecRun.FeatureAttribute("Survival_DecreaseSurvivalDataOnGameTurn", Description="\tЧтобы ввести микроменеджмент ресурсов и состояния персонажей\r\n\tКак игроку\r\n\tМне " +
        "нужно, чтобы каждый ход значение показателей сытости/воды/усталости персонажа па" +
        "дало", SourceFile="TestCases\\Survival_DecreaseSurvivalDataOnGameTurn.feature", SourceLine=0)]
    public partial class Survival_DecreaseSurvivalDataOnGameTurnFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Survival_DecreaseSurvivalDataOnGameTurn.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Survival_DecreaseSurvivalDataOnGameTurn", "\tЧтобы ввести микроменеджмент ресурсов и состояния персонажей\r\n\tКак игроку\r\n\tМне " +
                    "нужно, чтобы каждый ход значение показателей сытости/воды/усталости персонажа па" +
                    "дало", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        public virtual void ПадениеПоказателейВыживанияКаждыйИгровойХод(string moveDistance, string stat, string statRate, string expectedStatValue, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "survival",
                    "dev0"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Падение показателей выживания каждый игровой ход", null, @__tags);
#line 7
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 8
 testRunner.Given("Есть карта размером 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.And("Есть актёр игрока класса captain в ячейке (0, 0)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.When(string.Format("Я перемещаю персонажа на {0} клетку", moveDistance), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
 testRunner.Then(string.Format("Значение {0} уменьшилось на {1} и стало {2}", stat, statRate, expectedStatValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Падение показателей выживания каждый игровой ход, Variant 0", new string[] {
                "survival",
                "dev0"}, SourceLine=14)]
        public virtual void ПадениеПоказателейВыживанияКаждыйИгровойХод_Variant0()
        {
#line 7
this.ПадениеПоказателейВыживанияКаждыйИгровойХод("1", "сытость", "1", "49", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Падение показателей выживания каждый игровой ход, Variant 1", new string[] {
                "survival",
                "dev0"}, SourceLine=14)]
        public virtual void ПадениеПоказателейВыживанияКаждыйИгровойХод_Variant1()
        {
#line 7
this.ПадениеПоказателейВыживанияКаждыйИгровойХод("1", "вода", "1", "49", ((string[])(null)));
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
