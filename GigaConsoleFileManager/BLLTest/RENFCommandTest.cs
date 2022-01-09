using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Commands;
using Xunit;

namespace BLLTest
{
    public class RENFCommandTest
    {
        [Fact]
        public void RENFCantFindFile()
        {
            // Arrange
            var cd = new CDCommand();
            cd.Execute(@"cd D:\Stationery");
            var renfcom = new RENFCommand();
            var command = "renf Gleboty.zip Dimoty.zip";

            // Act
            var act = () => renfcom.Execute(command);

            // Assert
            Assert.Throws<FileNotFoundException>(act);
        }

        [Fact]
        public void RENFCanFindFile()
        {
            // Arrange
            var cd = new CDCommand();
            cd.Execute(@"cd D:\Stationery");
            var renfcom = new RENFCommand();
            var crfcom = new CRFCommand();
            var command = "renf Gleboty.zip Dimoty.zip";
            crfcom.Execute("crf Gleboty.zip");

            // Act
            renfcom.Execute(command);

            // Assert
            Assert.True(File.Exists(Directory.GetCurrentDirectory() + @"\" + "Dimoty.zip"));
        }
    }
}
