using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Hadoop.MapReduce;

namespace HDInsightDemo
{
    public class CountryJob : HadoopJob<CountryMapper, CountryReducer>
    {
        #region Overrides of HadoopJob

        public override HadoopJobConfiguration Configure(ExecutorContext context)
        {
            var configuration = new HadoopJobConfiguration
            {
                InputPath = "asv:///countries/input_large.log",
                OutputFolder = "asv:///countrycount",      
            };
            return configuration;

        }

        #endregion
    }

}
