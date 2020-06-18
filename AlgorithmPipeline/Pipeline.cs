using System;
using System.Collections.Generic;

namespace AlgorithmPipeline
{
    public class Pipeline : Dictionary<string, IPipelineStep>
    {
        Dictionary<string, PipelineData> Results;
        Pipeline() : base() { }
        Pipeline(int capacity) : base(capacity) { }

        /// <summary>
        /// Main constructor with pre-given steps
        /// </summary>
        /// <param name="pipeline"></param>
        public Pipeline(Dictionary<string, IPipelineStep> pipeline)
        {
            Results = new Dictionary<string, PipelineData>(pipeline.Count);

            foreach (var pipelineStep in pipeline)
                this.Add(pipelineStep.Key, pipelineStep.Value);
        }

        /// <summary>
        /// Run steps
        /// </summary>
        /// <returns></returns>
        public PipelineData Run(object firstInput)
        {
            PipelineData res = new PipelineData();
            object input = firstInput;

            foreach (var pipelineStep in this)
            {
                res = pipelineStep.Value.Run(input);
                Results[pipelineStep.Key] = res;
                input = (res.DataType != null) ? Convert.ChangeType(res.Data, res.DataType);
            }

            return res;
        }
    }
}
