using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Hadoop.MapReduce;

namespace HDInsightDemo
{
    public class CountryMapper : Microsoft.Hadoop.MapReduce.MapperBase 
    {
        #region Overrides of MapperBase
        
        public override void Map(string inputLine, MapperContext context)
        {
            string[] terms = inputLine.Split('\t');
            // add a sanity check in case we have a data quality issue
            if (terms.Length != 6)
                return;

            // get the country part out
            string country = terms[3];

            //const string purchaseConst = "Purchase";
            //string purchase = terms[5];

            //if (purchase == purchaseConst)
            //    context.EmitKeyValue(country, "1");

            context.EmitKeyValue(country, "1");
        }

        #endregion

    }
}
