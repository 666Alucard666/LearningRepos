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
    public class DELDCommandTest
    {
        [Fact]
        public void DELDCanDelete()
        {
            // Arrange
            var crdcom = new CRDCommand();
            var deldcom = new DELDCommand();
            var command = "deld Kikus";
            crdcom.Execute("crd Kikus");

            // Act
            deldcom.Execute(command);

            // Assert
            Assert.True(!Directory.Exists(Directory.GetCurrentDirectory() + @"\" + "Kikus"));
        }

        [Fact]
        public void DELDCantDelete()
        {
            // Arrange
            var deldcom = new DELDCommand();
            var command = "deld Kikus";

            // Act
            var act = () => deldcom.Execute(command);

            // Assert
            Assert.Throws<DirectoryNotFoundException>(act);
        }
    }
}
