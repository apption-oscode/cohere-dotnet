namespace Cohere.Models;

public class RerankRequest: ICohereRequest
{
    // Visit https://docs.cohere.com/reference/rerank#request for more information on the input fields

    // <summary>
    // The model to use for text reranking
    // </summary>
    public string? Model { get; set; } = "rerank-english-v3.0";

    // <summary>
    // The query to use for text reranking
    // </summary>
    public required string Query { get; set; }

    // <summary>
    // The list of texts to rerank
    // </summary>
    public required List<string> Documents { get; set; }

    // <summary>
    // The number of most relevant documents or indices to return
    // </summary>
    public int? TopN { get; set; }

    // <summary>
    // If a JSON object is provided, you can specify which keys you would like to have considered for reranking
    // </summary>
    public List<string>? RankFields { get; set;}

    // <summary>
    // Specifies whether to return results with or without doc text
    // </summary>
    public bool? ReturnDocuments { get; set; }

    // <summary>
    // The maximum number of chunks to produce internally from a document
    // </summary>
    public int? MaxChunksPerDoc { get; set; }
}