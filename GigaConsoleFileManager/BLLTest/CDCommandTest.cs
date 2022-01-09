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
    public class CDCommandTest
    {
        [Fact]
        public void CDChooseWrongDirectory()
        {
            // Arrange
            var cdcom = new CDCommand();
            var command = "cd D:" + Path.DirectorySeparatorChar + "Bahilda";

            // Act
            Action act = () => cdcom.Execute(command);

            // Assert
            Assert.Throws<DirectoryNotFoundException>(act);
        }

        [Fact]
        public void CDChooseRightDirectory()
        {
            // Arrange
            var cdcom = new CDCommand();
            var command = "cd D:" + Path.DirectorySeparatorChar;

            // Act
            string? result = cdcom.Execute(command);

            // Assert
            Assert.Matches("Success!", result);
        }
    }
}
