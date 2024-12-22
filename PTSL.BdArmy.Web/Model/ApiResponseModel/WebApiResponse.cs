using Newtonsoft.Json;
using PTSL.BdArmy.Web.Helper.Enum;

namespace PTSL.BdArmy.Web.Model
{
    public class WebApiResponse<T>
    {
        public WebApiResponse()
        { }

        public WebApiResponse((ExecutionState executionState, T entity, string message) result)
        {
            ExecutionState = result.executionState;
            Data = result.entity;
            Message = result.message;
        }

        public WebApiResponse((ExecutionState executionState, string message) result)
        {
            ExecutionState = result.executionState;
            Message = result.message;
        }

        [JsonProperty("ExecutionState")]
        public ExecutionState ExecutionState { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("Data")]
        public T Data { get; set; }
    }
}
