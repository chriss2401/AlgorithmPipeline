using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmPipeline
{
    /// <summary>
    /// Class for holding data that will be either outputted or used in <see cref="Pipeline"/>
    /// </summary>
    public class PipelineData : IPipelineData
    {
        public object Data { get; set; }
        public Type DataType { get; set; }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public PipelineData()
        {

        }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public PipelineData(object data, Type dataType = null)
        {
            Data = data;
            DataType = dataType;
        }
    }
}
