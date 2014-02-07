using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Hadoop.MapReduce;
using System.Globalization;

namespace HDInsightDemo
{
    public class CountryReducer : Microsoft.Hadoop.MapReduce.ReducerCombinerBase
    {
        #region Overrides of ReducerCombinerBase
 
        public override void Reduce(string key, IEnumerable<string> values, ReducerCombinerContext context)
        {
            context.EmitKeyValue(key, values.Count().ToString(CultureInfo.InvariantCulture));
        }
 
        #endregion
    }
}
