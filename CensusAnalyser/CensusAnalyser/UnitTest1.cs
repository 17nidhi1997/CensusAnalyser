using CensersAnalyser;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.IO;
namespace CensusAnalyser
{
    /// <summary>
    /// Unit Testing of CensusAnalyserProblem project.
    /// </summary>
    public class Tests
    {

        /// <summary>
        /// Test Case 1.1
        /// Match the records.
        /// </summary>
        [Test]
        public void GivenNoOfRecords_WhenNumOfRecoder_ShouldReturnsNoOfRecordesInCSV()
        {
            try
            {
                string path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\sateCensusAnalyser.csv";
                Factory factory = new Factory();
                DelegateCsvStateDataLoadDAO deleget = new DelegateCsvStateDataLoadDAO(Builder.Construct);
                int expected = StateCensusAnalyser.CSVLoadData(path);
                Assert.AreEqual(expected.ToString(), deleget(factory.GetObjectCSVStateCensus(), path, ""));
            }
            catch (Exception e)
            {

                _ = e.StackTrace;
            }
        }

        /// <summary>
        /// Test Case 1.2
        /// Throw the exception if wrong file path pass.
        /// </summary>
        [Test]
        public void GivenFilePathIncorrect_WhenCheckFilePath_ShouldReturnsFileNotFoundException()
        {
            Factory factory = new Factory();
            DelegateCsvStateDataLoadDAO deleget = new DelegateCsvStateDataLoadDAO(Builder.Construct);
            var ex = Assert.Throws<FileNotFoundException>(() => deleget(factory.GetObjectCSVStateCensus(), "Wrong_File_Path", "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));

        }

        /// <summary>
        /// Test Case 1.3
        /// throw the exception if wrong extension file pass.
        /// </summary>
        [Test]
        public void GivenFileExtansionIncorrect_WhenCheckFilePath_ShouldReturnsFileNotFoundException()
        {
            try
            {
                string path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\sateCensusAnalyser.txt";
                Factory factory = new Factory();
                DelegateCsvStateDataLoadDAO deleget = new DelegateCsvStateDataLoadDAO(Builder.Construct);
                var ex = Assert.Throws<FileNotFoundException>(() => deleget(factory.GetObjectCSVStateCensus(), path, "State,Population,AreaInSqKm,DensityPerSqKm"));
                Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
            }
            catch (FileNotFoundException e)
            {

                _ = e.StackTrace;
            }
        }


        /// <summary>
        /// Test Case 1.4
        /// throw the exception if wrong delimiter pass.
        /// </summary>
        [Test]
        public void GivenWrong_Delimiter_WhenDelimiterIsWrong_ShouldPassWrongDelimiter()
        {
            string path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\wrongCSVStateCensus.csv";
            Factory factory = new Factory();
            DelegateCsvStateDataLoadDAO deleget = new DelegateCsvStateDataLoadDAO(Builder.Construct);
            var ex = Assert.Throws<CensusAnalyserException>(() => deleget(factory.GetObjectCSVStateCensus(), path, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.That(ex.mgs, Is.EqualTo(CensusException.Wrong_Delimiter.ToString()));
        }

        /// <summary>
        /// Test Case 1.5
        /// throw the exception if wrong header pass.
        /// </summary>
        [Test]
        public void GivenWrongHeader_WhenHeaderDontMatch_ShouldPassWrongHeader()
        {
            string path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\sateCensusAnalyser.csv";
            Factory factory = new Factory();
            DelegateCsvStateDataLoadDAO deleget = new DelegateCsvStateDataLoadDAO(Builder.Construct);
            var ex = Assert.Throws<CensusAnalyserException>(() => deleget(factory.GetObjectCSVStateCensus(), path, "Wrong_Header"));
            Assert.That(ex.mgs, Is.EqualTo(CensusException.Wrong_Header.ToString()));

        }

        /// <summary>
        /// Test Case 2.1
        /// Match the records.
        /// </summary>
        [Test]
        public void GivenNoOfRecords_WhenNumOfRecoder_ShouldReturnsNoOfRecordesInCSV1()
        {
            try
            {
                string path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\StateCode.csv";
                Factory factory = new Factory();
                DelegateCsvStateDataLoadDAO deleget = new DelegateCsvStateDataLoadDAO(Builder.Construct);
                int expected = StateCensusAnalyser.CSVLoadData(path);
                Assert.AreEqual(expected.ToString(), deleget(factory.GetObjectCSVStateCensus(), path, "SrNo,State,Name,TIN,StateCode"));
            }
            catch (Exception e)
            {

                _ = e.StackTrace;
            }
        }


        /// <summary>
        /// Test Case 2.2
        /// Throw the exception if wrong file path pass.
        /// </summary>
        [Test]
        public void GivenFilePathIncorrect_WhenCheckFilePath_ShouldReturnsFileNotFoundException1()
        {
            Factory factory = new Factory();
            DelegateCsvStateDataLoadDAO deleget = new DelegateCsvStateDataLoadDAO(Builder.Construct);
            var ex = Assert.Throws<FileNotFoundException>(() => deleget(factory.GetObjectCSVStateCensus(), "Wrong_File_Path", "SrNo, State, Name, TIN, StateCode"));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
        }

        /// <summary>
        /// Test Case 2.3
        /// Throw the exception if wrong extension file pass.
        /// </summary>
        [Test]
        public void GivenFileExtansionIncorrect_WhenCheckFilePath_ShouldReturnsFileNotFoundException1()
        {
            try
            {
                string path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\StateCode.txt";
                Factory factory = new Factory();
                DelegateCsvStateDataLoadDAO deleget = new DelegateCsvStateDataLoadDAO(Builder.Construct);
                var ex = Assert.Throws<FileNotFoundException>(() => deleget(factory.GetObjectCSVStateCensus(), path, "SrNo, State, Name, TIN, StateCode"));
                Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
            }
            catch (FileNotFoundException e)
            {

                _ = e.StackTrace;
            }
        }

        /// <summary>
        /// Test Case 2.4
        /// throw the exception if wrong delimiter pass.
        /// </summary>
        [Test]
        public void GivenWrong_Delimiter_WhenDelimiterIsWrong_ShouldPassWrongDelimiter1()
        {
            string path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\WrongCSVFile.csv";
            Factory factory = new Factory();
            DelegateCsvStateDataLoadDAO deleget = new DelegateCsvStateDataLoadDAO(Builder.Construct);
            var ex = Assert.Throws<CensusAnalyserException>(() => deleget(factory.GetObjectCSVStateCensus(), path, "SrNo,State,Name,TIN,StateCode"));
            Assert.That(ex.mgs, Is.EqualTo(CensusException.Wrong_Delimiter.ToString()));
        }

        /// <summary>
        /// Test Case 2.5
        /// throw the exception if wrong header pass.
        /// </summary>
        [Test]
        public void GivenWrongHeader_WhenHeaderDontMatch_ShouldPassWrongHeader1()
        {
            string path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\StateCode.csv";
            Factory factory = new Factory();
            DelegateCsvStateDataLoadDAO deleget = new DelegateCsvStateDataLoadDAO(Builder.Construct);
            var ex = Assert.Throws<CensusAnalyserException>(() => deleget(factory.GetObjectCSVStateCensus(), path, "Wrong_Header"));
            Assert.That(ex.mgs, Is.EqualTo(CensusException.Wrong_Header.ToString()));
        }

        /// <summary>
        /// Test Case 3.1
        /// </summary>
        [Test]
        public void Givenjsonfile_WhenfirstAndLastStats_shouldMatchTheFollowingState()
        {
            string expectedFirstState = "Andhra Pradesh";
            string expectedLastState = "West Bengal";
            string path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\CSVStateCensus.json";
            JArray a = new JArray(utility.SortCensus(path));
            string firstState = a[0]["State"].Value<string>();
            string lastState = a[28]["State"].Value<string>();
            Assert.AreEqual(expectedFirstState, firstState);
            Assert.AreEqual(expectedLastState, lastState);
        }

        /// <summary>
        /// Test Case 4.1
        /// </summary>
        [Test]
        public void GivenJsonFile_whenComparingFistStateCode_ShouldMatchStateCode()
        {

            string jsonFilePath = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\CSVStateCode.json";
            string actual = utility1.FirstElementNameOfJsonArray(jsonFilePath, "StateName");
            string expected = "Andaman and Nicobar Islands";
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// Test Case 4.2
        /// </summary>
        [Test]
        public void GivenJsonFile_whenComparingLastStateCode_ShouldMatchStateCode()
        {
            string jsonFilePath = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\CSVStateCode.json";
            string actual = utility1.LastElementNameOfJsonArray(jsonFilePath, "StateName");
            string expected = "West Bengal";
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// Test Case 4.2
        /// </summary>
        [Test]
        public void Givenjsonfile_WhenfirstAndLastpopulous_shouldMatchTheFollowingpopulation()
        {
            int expectedFirstState = 607688;
            int expectedLastState = 199812341;
            string path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\CSVStateCensus.json";
            JArray a = new JArray(utility.SortCensus(path));
            int firstState = a[0]["Population"].Value<int>();
            int lastState = a[28]["Population"].Value<int>();
            Assert.AreEqual(expectedFirstState, firstState);
            Assert.AreEqual(expectedLastState, lastState);
        }
    }
}