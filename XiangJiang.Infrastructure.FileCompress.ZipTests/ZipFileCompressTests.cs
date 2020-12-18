using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XiangJiang.Infrastructure.Abstractions;
using XiangJiang.Infrastructure.FileCompress.Zip;

namespace XiangJiang.Infrastructure.FileCompress.ZipTests
{
    [TestClass]
    public class ZipFileCompressTests
    {
        private IFileCompressProvider _fileCompressProvider;

        [TestInitialize]
        public void Init()
        {
            _fileCompressProvider = new ZipFileCompress();
        }

        [TestMethod]
        public void CompressTest()
        {
            var compressFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            var zipFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AnyDesk.zip");
            _fileCompressProvider.Compress(compressFolder, zipFile);
            Assert.IsTrue(File.Exists(zipFile));
        }

        [TestMethod]
        public void ExtractTest()
        {
            var extractFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AnyDesk");
            var zipFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "AnyDesk.zip");
            _fileCompressProvider.Extract(zipFile, extractFolder);
            Assert.IsTrue(Directory.Exists(extractFolder));
            Assert.IsTrue(File.Exists(Path.Combine(extractFolder, "AnyDesk.exe")));
        }
    }
}