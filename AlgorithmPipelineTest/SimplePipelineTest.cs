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
            /*
            Func<object, object> powAdd = (x) =>
            {
                var pow = Math.Pow(Convert.ToDouble(x), 2);
                return pow + 5;
            };

            Func<object, object> divideTen = (x) => Convert.ToDouble(x) / 10;

            var pipelineStepsTwo = new Dictionary<string, Func<object, object>>()
            {
                {"powerOfTwo", powAdd},
                {"divideByTen", divideTen}
            };

            var resfd = divideTen(10);
            */

            var pipelineSteps = new Dictionary<string, IPipelineStep>() 
            {
                {"powerOfTwo", new PowerTwoStep()},
                {"divideByTen", new DivideTenStep()} 
            };

            var pipeline = new Pipeline(pipelineSteps);
            var res = pipeline.Run(2);
            var dataRes = Convert.ToDouble(res.Data);
            Assert.IsTrue(dataRes == 0.4);
        }

        #region internal pipeline steps
        internal class PowerTwoStep : IPipelineStep
        {
            public PowerTwoStep()
            {
            }

            PipelineData IPipelineStep.Run(object input)
            {
                var castedInput = Convert.ToDouble(input);
                return new PipelineData(Math.Pow(castedInput, 2), typeof(Double));
            }
        }

        internal class DivideTenStep : IPipelineStep
        {
            public DivideTenStep()
            {
            }

            PipelineData IPipelineStep.Run(object input)
            {
                var castedInput = Convert.ToDouble(input);
                return new PipelineData(castedInput/10, typeof(Double));
            }
        }
        #endregion
    }
}
