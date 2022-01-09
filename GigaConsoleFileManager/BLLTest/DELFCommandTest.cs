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
    public class DELFCommandTest
    {
        [Fact]
        public void DELFCanDelete()
        {
            // Arrange
            var cd = new CDCommand();
            cd.Execute(@"cd D:\Stationery");
            var crfcom = new CRFCommand();
            var delfcom = new DELFCommand();
            var command = "delf Gleboty.txt";
            crfcom.Execute("crf Gleboty.txt");

            // Act
            delfcom.Execute(command);

            // Assert
            Assert.True(!File.Exists(Directory.GetCurrentDirectory() + "Gleboty"));
        }

        [Fact]
        public void DELFCantDelete()
        {
            // Arrange
            var cd = new CDCommand();
            cd.Execute(@"cd D:\Stationery");
            var delfcom = new DELFCommand();
            var command = "delf Gleboty.txt";

            // Act
            var act = () => delfcom.Execute(command);

            // Assert
            Assert.Throws<FileNotFoundException>(act);
        }
    }
}
