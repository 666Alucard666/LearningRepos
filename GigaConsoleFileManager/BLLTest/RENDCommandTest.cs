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
    public class RENDCommandTest
    {
        [Fact]
        public void RENDCantFindDirectory()
        {
            // Arrange
            var rendcom = new RENDCommand();
            var command = "rend Kifkus Fikus";
            var cd = new CDCommand();
            cd.Execute(@"cd D:\Stationery");

            // Act
            var act = () => rendcom.Execute(command);

            // Assert
            Assert.Throws<DirectoryNotFoundException>(act);
        }

        [Fact]
        public void RENDCanFindDirectory()
        {
            // Arrange
            var cd = new CDCommand();
            cd.Execute(@"cd D:\Stationery");
            var rendcom = new RENDCommand();
            var crdcom = new CRDCommand();
            var command = "rend Kifkus Fikus";
            crdcom.Execute("crd Kifkus");

            // Act
            rendcom.Execute(command);

            // Assert
            Assert.True(Directory.Exists(Directory.GetCurrentDirectory() + @"\" + "Fikus"));
            new DELDCommand().Execute("deld Fikus");
        }
    }
}
