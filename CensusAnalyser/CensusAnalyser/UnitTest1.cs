using NUnit.Framework;
using System.IO;
namespace CensusAnalyser
{
    public class Tests
    {
      
            [Test]
            public void GivenNoOfRecords_WhenNumOfRecoder_ShouldReturnsNoOfRecordesInCSV()
            {
                string Path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\sateCensusAnalyser.csv";
                int actual = CSVStateCensus.StateLoadData(Path);
                Assert.AreEqual(30, actual);
            }

            [Test]
            public void GivenFilePathIncorrect_WhenCheckFilePath_ShouldReturnsFileNotFoundException()
            {
                var ex = Assert.Throws<FileNotFoundException>(() => CSVStateCensus.StateLoadData("Wrong_File_Path"));
                Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
            }


            [Test]
            public void GivenFileExtansionIncorrect_WhenCheckFilePath_ShouldReturnsFileNotFoundException()
            {
                string Path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\sateCensusAnalyser.txt";
                var ex = Assert.Throws<FileNotFoundException>(() => CSVStateCensus.StateLoadData(Path));
                Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
            }


            [Test]
            public void GivenWrong_Delimiter_WhenDelimiterIsWrong_ShouldPassWrongDelimiter()
            {
                string Path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\sateCensusAnalyser.csv";
                var ex = Assert.Throws<CensusAnalyserException>(() => CSVStateCensus.CheckDelimiter(Path, "State,Population,AreaInSqKm,DensityPerSqKm"));
                Assert.That(ex.mgs, Is.EqualTo(CensusException.Wrong_Delimiter.ToString()));
            }


            [Test]
            public void GivenWrongHeader_WhenHeaderDontMatch_ShouldPassWrongHeader()
            {
                string Path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\sateCensusAnalyser.csv";
                var ex = Assert.Throws<CensusAnalyserException>(() => CSVStateCensus.CheckDelimiter(Path, "Wrong_Header"));
                Assert.That(ex.mgs, Is.EqualTo(CensusException.Wrong_Delimiter.ToString()));
            }

            //USECASE 2: state code csv
            [Test]
            public void GivenNoOfRecords_WhenNumOfRecoder_ShouldReturnsNoOfRecordesInCSV1()
            {
                string Path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\sateCode.csv";
                int actual = CSVStateCensus.StateLoadData(Path);
                Assert.AreEqual(30, actual);
            }

            [Test]
            public void GivenFilePathIncorrect_WhenCheckFilePath_ShouldReturnsFileNotFoundException1()
            {
                var ex = Assert.Throws<FileNotFoundException>(() => CSVStateCensus.StateLoadData("Wrong_File_Path"));
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
                string Path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\sateCode.csv";
                var ex = Assert.Throws<CensusAnalyserException>(() => CSVStateCensus.CheckDelimiter(Path, "State,Population,AreaInSqKm,DensityPerSqKm"));
                Assert.That(ex.mgs, Is.EqualTo(CensusException.Wrong_Delimiter.ToString()));
            }


            [Test]
            public void GivenWrongHeader_WhenHeaderDontMatch_ShouldPassWrongHeader1()
            {
                string Path = @"C:\Users\Srinidhi\source\repos\CensersAnaliserProblem\CensersAnaliserProblem\sateCode.csv";
                var ex = Assert.Throws<CensusAnalyserException>(() => CSVStateCensus.CheckDelimiter(Path, "Wrong_Header"));
                Assert.That(ex.mgs, Is.EqualTo(CensusException.Wrong_Delimiter.ToString()));
            }
        
    }
}

    