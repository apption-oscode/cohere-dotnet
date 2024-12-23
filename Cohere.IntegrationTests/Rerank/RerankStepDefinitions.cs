using Cohere.Types.Rerank;
using Cohere.Types.Shared;
using Cohere.Tests.SampleRequestsAndResponses;
using Reqnroll;
using Xunit;

namespace Cohere.IntegrationTests;

/// <summary>
/// Step definitions for the Rerank feature
/// </summary>
public partial class CohereStepDefinitions
{
    private RerankResponse? _rerankResponse;

    /// <summary>
    /// Sends a valid rerank request with various configurations to the Cohere API endpoint
    /// </summary>
    [When(@"I send a valid rerank request with ""(.*)""")]
    public async Task WhenISendAValidRerankRequestWith(string testCase)
    {
        if (_client != null)
        {
            _rerankResponse = await _client.RerankAsync(SampleRerankRequests.GetRerankRequest(testCase));
        }
        else
        {
            throw new InvalidOperationException("Client is not initialized.");
        }
    }

    /// <summary>
    /// Sends an invalid rerank request with various incorrect configurations to the Cohere API endpoint
    /// </summary>
    [When(@"I send an invalid rerank request with ""(.*)""")]
    public async Task WhenISendAnInvalidRerankRequestWith(string invalidCase)
    {
        try
        {
            if (_client != null)
            {
                _rerankResponse = await _client.RerankAsync(SampleRerankRequests.GetRerankRequest(invalidCase));
            }
            else
            {
                throw new InvalidOperationException("Client is not initialized.");
            }
        }
        catch (Exception ex)
        {
            _caughtException = ex;
        }
    }

    /// <summary>
    /// Verifies that a valid rerank response is received from the Cohere API and checks response types
    /// </summary>
    [Then(@"I should receive a valid rerank response")]
    public void ThenIShouldReceiveAValidRerankResponse()
    {
        Assert.NotNull(_rerankResponse);
        Assert.IsType<string>(_rerankResponse.Id);
        Assert.NotNull(_rerankResponse.Results);
        Assert.All(_rerankResponse.Results, result =>
        {
            Assert.IsType<int>(result.Index);
            Assert.IsType<double>(result.RelevanceScore);
        });
    }

    /// <summary>
    /// Verifies that an error response is received for an invalid rerank request
    /// </summary>
    [Then(@"I should receive a rerank error response")]
    public void ThenIShouldReceiveARerankErrorResponse()
    {
        Assert.NotNull(_caughtException);
        Assert.IsType<CohereApiException>(_caughtException);
        _output?.WriteLine(_caughtException.ToString());
    }

    /// <summary>
    /// Sends a valid rerank request and cancels it immediately
    /// </summary>
    [When("I send a valid rerank request and cancel it immediately")]
    public async Task WhenISendAValidRerankRequestAndCancelItImmediately()
    {
        using var cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.Cancel();

        try
        {
            if (_client != null)
            {
                _rerankResponse = await _client.RerankAsync(SampleRerankRequests.BasicValidRequest, cancellationTokenSource.Token);
            }
            else
            {
                throw new InvalidOperationException("Client is not initialized.");
            }
        }
        catch (OperationCanceledException ex)
        {
            _caughtException = ex;
        }
    }

    /// <summary>
    /// Verifies that the rerank request is canceled, and an OperationCanceledException is raised
    /// </summary>
    [Then("the rerank request should be canceled, and an OperationCanceledException should be raised")]
    public void ThenTheRerankRequestShouldBeCanceledAndAnOperationCanceledExceptionShouldBeRaised()
    {
        Assert.NotNull(_caughtException);
        Assert.IsType<OperationCanceledException>(_caughtException);
    }
}