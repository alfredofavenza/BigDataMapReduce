using Microsoft.Hadoop.MapReduce;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDInsightDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            bool debug = false;

            if (debug)
            {
                using (var reader = new StreamReader("916kb_large.log"))
                {
                    string sample = reader.ReadToEnd();
                    var output = StreamingUnit.Execute<CountryMapper, CountryReducer>(sample.Split(new[] { '\r', '\n' }));
                    foreach (string result in output.ReducerResult)
                    {
                        Console.WriteLine(result);
                    }
                    Console.ReadLine();
                }
            }
            else
            {
                Environment.SetEnvironmentVariable("JAVA_HOME", "this_is_a_BUG", EnvironmentVariableTarget.Process);
                Environment.SetEnvironmentVariable("HADOOP_HOME", "this_is_a_BUG", EnvironmentVariableTarget.Process);

                //var azureCluster = new Uri("https://alfBigDataCluster.azurehdinsight.net:563");
                var azureCluster = new Uri("https://alfBigDataCluster.azurehdinsight.net");
                var clusterUsername = "alfredo";
                var clusterPassword = "alf@Mic123";

                var hadoopUserName = "Hadoop";

                //var storageAccount = "idofhdinsightold.blob.core.windows.net";
                //var storageKey = "LVLdWHxAJGjAK4nAp4FHpV0DMB0tM7ay9Qn+0Wo5RUqQfWMgMU2BDKBxt6VEqFa3Ml4j7jsiX4/gdVPcnN7Rbg==";
                var storageAccount = "parislab.blob.core.windows.net";
                var storageKey = "9glcovmDSobwi3VgXyW6e6hORYvpUYxR4obatRW9RLsVYA+7C6KsYZxEOZTWYIRWeBCFfH1SdUjgIApS4eLUjg==";
                var storageContainer = "working";

                bool createContainerIfNotExist = true;

                var hadoop = Hadoop.Connect(azureCluster, clusterUsername, hadoopUserName, clusterPassword, storageAccount, storageKey, storageContainer, createContainerIfNotExist);

                try
                {
                    var result = hadoop.MapReduceJob.ExecuteJob<CountryJob>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

        }
    }
}
