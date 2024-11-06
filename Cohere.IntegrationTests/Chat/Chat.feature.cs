﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:2.0.0.0
//      Reqnroll Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Cohere.IntegrationTests.Chat
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class ChatIntegrationFeature : object, Xunit.IClassFixture<ChatIntegrationFeature.FixtureData>, Xunit.IAsyncLifetime
    {
        
        private static global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Chat.feature"
#line hidden
        
        public ChatIntegrationFeature(ChatIntegrationFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
        }
        
        public static async System.Threading.Tasks.Task FeatureSetupAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(null, global::Reqnroll.xUnit.ReqnrollPlugin.XUnitParallelWorkerTracker.Instance.GetWorkerId());
            global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Chat", "Chat Integration", "  As a developer\r\n  I want to use the CohereClient class to interact with the Coh" +
                    "ere API Chat endpoint", global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
            await testRunner.OnFeatureStartAsync(featureInfo);
        }
        
        public static async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
            string testWorkerId = testRunner.TestWorkerId;
            await testRunner.OnFeatureEndAsync();
            testRunner = null;
            global::Reqnroll.xUnit.ReqnrollPlugin.XUnitParallelWorkerTracker.Instance.ReleaseWorker(testWorkerId);
        }
        
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
        }
        
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        public virtual async System.Threading.Tasks.Task FeatureBackgroundAsync()
        {
#line 7
  #line hidden
#line 8
    await testRunner.GivenAsync("I have a valid API key", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 9
    await testRunner.AndAsync("I have instantiated the Cohere client", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
        {
            await this.TestInitializeAsync();
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
        {
            await this.TestTearDownAsync();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Send a valid chat request with various settings")]
        [Xunit.TraitAttribute("FeatureTitle", "Chat Integration")]
        [Xunit.TraitAttribute("Description", "Send a valid chat request with various settings")]
        [Xunit.TraitAttribute("Category", "ValidRequests")]
        [Xunit.InlineDataAttribute("BasicValidRequest", new string[0])]
        [Xunit.InlineDataAttribute("MaxTokensRequest", new string[0])]
        [Xunit.InlineDataAttribute("TemperatureRequest", new string[0])]
        [Xunit.InlineDataAttribute("BoundaryKAndPZeroAndOne", new string[0])]
        [Xunit.InlineDataAttribute("BoundaryKAndPMaxAndMin", new string[0])]
        [Xunit.InlineDataAttribute("FiveStopSequencesRequest", new string[0])]
        public async System.Threading.Tasks.Task SendAValidChatRequestWithVariousSettings(string testCase, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ValidRequests"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("TestCase", testCase);
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Send a valid chat request with various settings", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 12
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 7
  await this.FeatureBackgroundAsync();
#line hidden
#line 13
    await testRunner.WhenAsync(string.Format("I send a valid chat request with \"{0}\"", testCase), ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 14
    await testRunner.ThenAsync("I should receive a valid chat response", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Send an invalid chat request with incorrect settings")]
        [Xunit.TraitAttribute("FeatureTitle", "Chat Integration")]
        [Xunit.TraitAttribute("Description", "Send an invalid chat request with incorrect settings")]
        [Xunit.TraitAttribute("Category", "InvalidRequests")]
        [Xunit.InlineDataAttribute("InvalidMaxTokens", new string[0])]
        [Xunit.InlineDataAttribute("InvalidTemperature", new string[0])]
        [Xunit.InlineDataAttribute("InvalidSafetyMode", new string[0])]
        [Xunit.InlineDataAttribute("ExceedStopSequencesLimit", new string[0])]
        [Xunit.InlineDataAttribute("MissingRequiredFields", new string[0])]
        public async System.Threading.Tasks.Task SendAnInvalidChatRequestWithIncorrectSettings(string invalidCase, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "InvalidRequests"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("InvalidCase", invalidCase);
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Send an invalid chat request with incorrect settings", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 26
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 7
  await this.FeatureBackgroundAsync();
#line hidden
#line 27
    await testRunner.WhenAsync(string.Format("I send an invalid chat request with \"{0}\"", invalidCase), ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 28
    await testRunner.ThenAsync("I should receive an error response", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : object, Xunit.IAsyncLifetime
        {
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
            {
                await ChatIntegrationFeature.FeatureSetupAsync();
            }
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
            {
                await ChatIntegrationFeature.FeatureTearDownAsync();
            }
        }
    }
}
#pragma warning restore
#endregion
