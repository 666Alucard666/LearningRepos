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
    public class CRFCommandTest
    {
        [Fact]
        public void CRFIsNotCreateFile()
        {
            // Arrange
            var crfcom = new CRFCommand();
            var command = string.Empty;

            // Act
            var act = () => crfcom.Execute(command);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void CRFBadFileName()
        {
            // Arrange
            var crfcom = new CRFCommand();
            var command = "crd /]/]><?/.,~" + Path.DirectorySeparatorChar;

            // Act
            var act = () => crfcom.Execute(command);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void CRFCReateFile()
        {
            // Arrange
            var crfcom = new CRFCommand();
            var command = "crf Karta.pdf";

            // Act
            var result = crfcom.Execute(command);

            // Assert
            Assert.Equal("Success!", result);
        }
    }
}
