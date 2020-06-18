using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmPipeline
{
    /// <summary>
    /// Interface for a <see cref="Pipeline"/> step
    /// </summary>
    public interface IPipelineStep
    {
        PipelineData Run(object input);
    }
}
