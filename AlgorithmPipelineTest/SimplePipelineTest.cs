using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmPipeline;
using System.IO;
using System.Collections.Generic;

namespace AlgorithmPipelineTest
{
    [TestClass]
    public class SimplePipelineTest
    {
        [TestMethod]
        public void PowAndDividePipelineTest()
        {
            var pipelineSteps = new Dictionary<string, IPipelineStep>() 
            {
                {"powerOfTwo", new PowerTwoStep()},
                {"divideByTen", new DivideTenStep()} 
            };

            var pipeline = new Pipeline(pipelineSteps);
            var res = pipeline.Run(2);
            var dataRes = Convert.ToDouble(res.Data);
            Assert.IsTrue(dataRes.Equals(0.4));
        }

        #region internal pipeline steps
        internal class PowerTwoStep : IPipelineStep
        {
            public PipelineData Result { get; set; }
            public PowerTwoStep()
            {
                Result = new PipelineData();
            }

            PipelineData IPipelineStep.Run(object input)
            {
                var castedInput = Convert.ToDouble(input);
                Result = new PipelineData(Math.Pow(castedInput, 2), typeof(Double));
                return Result;
            }

            void Save()
            {
                if (Result.Data != null)
                {
                    var data = Convert.ChangeType(Result.Data, Result.DataType);
                    File.AppendAllText(@"out.txt", data.ToString());
                }
            }
        }

        internal class DivideTenStep : IPipelineStep
        {
            public PipelineData Result { get; set; }
            public DivideTenStep()
            {
                Result = new PipelineData();
            }

            PipelineData IPipelineStep.Run(object input)
            {
                var castedInput = Convert.ToDouble(input);
                Result = new PipelineData(castedInput / 10, typeof(Double));
                return Result;
            }

            void Save()
            {
                if (Result.Data != null)
                {
                    var data = Convert.ChangeType(Result.Data, Result.DataType);
                    File.AppendAllText(@"out.txt", data.ToString());
                }
            }
        }
        #endregion
    }
}
