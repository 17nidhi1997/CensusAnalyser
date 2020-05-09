using NUnit.Framework;
using System.IO;
using static CensusAnalyser.CSVStateCensus;

namespace CensusAnalyser
{
    public class Tests
    {

            [Test]
            public void GivenNoOfRecords_WhenNumOfRecoder_ShouldReturnsNoOfRecordesInCSV()
            {
            string Path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\sateCensusAnalyser.csv";
            DCsvStateDataLoad del = new DCsvStateDataLoad(CSVStateCensus.StateLoadData);
            int actual = del(Path);
            int expected = StateCensusAnalyser.CSVLoadData(Path);
            Assert.AreEqual(expected, actual);
        }

            [Test]
            public void GivenFilePathIncorrect_WhenCheckFilePath_ShouldReturnsFileNotFoundException()
            {
            DCsvStateDataLoad del = new DCsvStateDataLoad(CSVStateCensus.StateLoadData);
            var ex = Assert.Throws<FileNotFoundException>(() => del("Wrong_File_Path"));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
        }


            [Test]
            public void GivenFileExtansionIncorrect_WhenCheckFilePath_ShouldReturnsFileNotFoundException()
            {
            string Path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\sateCensusAnalyser.txt";
            DCsvStateDataLoad del = new DCsvStateDataLoad(CSVStateCensus.StateLoadData);
            var ex = Assert.Throws<FileNotFoundException>(() => del(Path));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
        }


            [Test]
            public void GivenWrong_Delimiter_WhenDelimiterIsWrong_ShouldPassWrongDelimiter()
            {
            string Path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\wrongCSVStateCensus.csv";
            DCheckCSVDelimiterAndHeader del = new DCheckCSVDelimiterAndHeader(CSVStateCensus.CheckDelimiterAndHeader);
            var ex = Assert.Throws<CensusAnalyserException>(() => del(Path, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.That(ex.mgs, Is.EqualTo(CensusException.Wrong_Delimiter.ToString()));
        }


            [Test]
            public void GivenWrongHeader_WhenHeaderDontMatch_ShouldPassWrongHeader()
            {
            string Path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\sateCensusAnalyser.csv";
            DCheckCSVDelimiterAndHeader del = new DCheckCSVDelimiterAndHeader(CSVStateCensus.CheckDelimiterAndHeader);
            var ex = Assert.Throws<CensusAnalyserException>(() => del(Path, "Wrong_Header"));
            Assert.That(ex.mgs, Is.EqualTo(CensusException.Wrong_Header.ToString()));
        }

            //USECASE 2: state code csv
            [Test]
            public void GivenNoOfRecords_WhenNumOfRecoder_ShouldReturnsNoOfRecordesInCSV1()
            {
            string Path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\StateCode.csv";
            DCsvStateDataLoad del = new DCsvStateDataLoad(CSVStateCensus.StateLoadData);
            int actual = del(Path);
            int expected = StateCensusAnalyser.CSVLoadData(Path);
            Assert.AreEqual(expected, actual);
        }

            [Test]
            public void GivenFilePathIncorrect_WhenCheckFilePath_ShouldReturnsFileNotFoundException1()
            {
            DCsvStateDataLoad del = new DCsvStateDataLoad(CSVStateCensus.StateLoadData);
            var ex = Assert.Throws<FileNotFoundException>(() => del("Wrong_File_Path"));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
        }


            [Test]
            public void GivenFileExtansionIncorrect_WhenCheckFilePath_ShouldReturnsFileNotFoundException1()
            {
                string Path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\sateCode.txt";
                var ex = Assert.Throws<FileNotFoundException>(() => CSVStateCensus.StateLoadData(Path));
                Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
            }


            [Test]
            public void GivenWrong_Delimiter_WhenDelimiterIsWrong_ShouldPassWrongDelimiter1()
            {
            string Path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\StateCode.txt";
            DCsvStateDataLoad del = new DCsvStateDataLoad(CSVStateCensus.StateLoadData);
            var ex = Assert.Throws<FileNotFoundException>(() => del(Path));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
        }


            [Test]
            public void GivenWrongHeader_WhenHeaderDontMatch_ShouldPassWrongHeader1()
            {
            string Path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\WrongCSVFile.csv";
            DCheckCSVDelimiterAndHeader del = new DCheckCSVDelimiterAndHeader(CSVStateCensus.CheckDelimiterAndHeader);
            var ex = Assert.Throws<CensusAnalyserException>(() => del(Path, "SrNo,State,Name,TIN,StateCode"));
            Assert.That(ex.mgs, Is.EqualTo(CensusException.Wrong_Delimiter.ToString()));
        }

        }
    }


    