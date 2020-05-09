using NUnit.Framework;
using System;
using System.IO;
namespace CensusAnalyser
{
    public class Tests
    {
        [Test]
        public void GivenNoOfRecords_WhenNumOfRecoder_ShouldReturnsNoOfRecordesInCSV()
        {
            try
            {
                string path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\sateCensusAnalyser.csv";
                Factory factory = new Factory();
                DelegateCsvStateDataLoad deleget = new DelegateCsvStateDataLoad(Builder.Construct);
                int expected = StateCensusAnalyser.CSVLoadData(path);
                Assert.AreEqual(expected.ToString(), deleget(factory.GetObjectCSVStateCensus(), path, ""));
            }
            catch (Exception e)
            {

                _ = e.StackTrace;
            }
        }

        [Test]
        public void GivenFilePathIncorrect_WhenCheckFilePath_ShouldReturnsFileNotFoundException()
        {
            Factory factory = new Factory();
            DelegateCsvStateDataLoad deleget = new DelegateCsvStateDataLoad(Builder.Construct);
            var ex = Assert.Throws<FileNotFoundException>(() => deleget(factory.GetObjectCSVStateCensus(), "Wrong_File_Path", "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));

        }


        [Test]
        public void GivenFileExtansionIncorrect_WhenCheckFilePath_ShouldReturnsFileNotFoundException()
        {
            try
            {
                string path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\sateCensusAnalyser.txt";
                Factory factory = new Factory();
                DelegateCsvStateDataLoad deleget = new DelegateCsvStateDataLoad(Builder.Construct);
                var ex = Assert.Throws<FileNotFoundException>(() => deleget(factory.GetObjectCSVStateCensus(), path, "State,Population,AreaInSqKm,DensityPerSqKm"));
                Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
            }
            catch (FileNotFoundException e)
            {

                _ = e.StackTrace;
            }
        }


        [Test]
        public void GivenWrong_Delimiter_WhenDelimiterIsWrong_ShouldPassWrongDelimiter()
        {
            string path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\wrongCSVStateCensus.csv";
            Factory factory = new Factory();
            DelegateCsvStateDataLoad deleget = new DelegateCsvStateDataLoad(Builder.Construct);
            var ex = Assert.Throws<CensusAnalyserException>(() => deleget(factory.GetObjectCSVStateCensus(), path, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.That(ex.mgs, Is.EqualTo(CensusException.Wrong_Delimiter.ToString()));
        }


        [Test]
        public void GivenWrongHeader_WhenHeaderDontMatch_ShouldPassWrongHeader()
        {
            string path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\sateCensusAnalyser.csv";
            Factory factory = new Factory();
            DelegateCsvStateDataLoad deleget = new DelegateCsvStateDataLoad(Builder.Construct);
            var ex = Assert.Throws<CensusAnalyserException>(() => deleget(factory.GetObjectCSVStateCensus(), path, "Wrong_Header"));
            Assert.That(ex.mgs, Is.EqualTo(CensusException.Wrong_Header.ToString()));

        //USECASE 2: state code csv
        [Test]
        public void GivenNoOfRecords_WhenNumOfRecoder_ShouldReturnsNoOfRecordesInCSV1()
        {
            try
            {
                string path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\StateCode.csv";
                Factory factory = new Factory();
                DelegateCsvStateDataLoad deleget = new DelegateCsvStateDataLoad(Builder.Construct);
                int expected = StateCensusAnalyser.CSVLoadData(path);
                Assert.AreEqual(expected.ToString(), deleget(factory.GetObjectCSVStateCensus(), path, "SrNo,State,Name,TIN,StateCode"));
            }
            catch (Exception e)
            {

                _ = e.StackTrace;
            }
        }

        [Test]
        public void GivenFilePathIncorrect_WhenCheckFilePath_ShouldReturnsFileNotFoundException1()
        {
            Factory factory = new Factory();
            DelegateCsvStateDataLoad deleget = new DelegateCsvStateDataLoad(Builder.Construct);
            var ex = Assert.Throws<FileNotFoundException>(() => deleget(factory.GetObjectCSVStateCensus(), "Wrong_File_Path", "SrNo, State, Name, TIN, StateCode"));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
        }


        [Test]
        public void GivenFileExtansionIncorrect_WhenCheckFilePath_ShouldReturnsFileNotFoundException1()
        {
            try
            {
                string path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\StateCode.txt";
                Factory factory = new Factory();
                DelegateCsvStateDataLoad deleget = new DelegateCsvStateDataLoad(Builder.Construct);
                var ex = Assert.Throws<FileNotFoundException>(() => deleget(factory.GetObjectCSVStateCensus(), path, "SrNo, State, Name, TIN, StateCode"));
                Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
            }
            catch (FileNotFoundException e)
            {

                _ = e.StackTrace;
            }
        }


        [Test]
        public void GivenWrong_Delimiter_WhenDelimiterIsWrong_ShouldPassWrongDelimiter1()
        {
            string path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\WrongCSVFile.csv";
            Factory factory = new Factory();
            DelegateCsvStateDataLoad deleget = new DelegateCsvStateDataLoad(Builder.Construct);
            var ex = Assert.Throws<CensusAnalyserException>(() => deleget(factory.GetObjectCSVStateCensus(), path, "SrNo,State,Name,TIN,StateCode"));
            Assert.That(ex.mgs, Is.EqualTo(CensusException.Wrong_Delimiter.ToString()));
        }


        [Test]
        public void GivenWrongHeader_WhenHeaderDontMatch_ShouldPassWrongHeader1()
        {
            string path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\StateCode.csv";
            Factory factory = new Factory();
            DelegateCsvStateDataLoad deleget = new DelegateCsvStateDataLoad(Builder.Construct);
            var ex = Assert.Throws<CensusAnalyserException>(() => deleget(factory.GetObjectCSVStateCensus(), path, "Wrong_Header"));
            Assert.That(ex.mgs, Is.EqualTo(CensusException.Wrong_Header.ToString()));
        }

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
        [Test]
        public void GivenJsonFile_whenComparingFistStateCode_ShouldMatchStateCode()
        {

            string jsonFilePath = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\CSVStateCode.json";
            string actual = utility1.FirstElementNameOfJsonArray(jsonFilePath, "StateName");
            string expected = "Andaman and Nicobar Islands";
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void GivenJsonFile_whenComparingLastStateCode_ShouldMatchStateCode()
        {
            string jsonFilePath = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\CSVStateCode.json";
            string actual = utility1.LastElementNameOfJsonArray(jsonFilePath, "StateName");
            string expected = "West Bengal";
            Assert.AreEqual(actual, expected);
        }
    }
}