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
    public class CRDCommandTest
    {
        [Fact]
        public void CRDIsNotCreateDirectory()
        {
            // Arrange
            var crdcom = new CRDCommand();
            var command = string.Empty;

            // Act
            var act = () => crdcom.Execute(command);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void CRDBadDirectoryName()
        {
            // Arrange
            var crdcom = new CRDCommand();
            var command = "crd /]/]><?/.,~" + Path.DirectorySeparatorChar;

            // Act
            var act = () => crdcom.Execute(command);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void CRDCReateDirectory()
        {
            // Arrange
            var crdcom = new CRDCommand();
            var command = "crd Kekis";

            // Act
            var result = crdcom.Execute(command);

            // Assert
            Assert.Equal("Success!", result);
        }
    }
}
