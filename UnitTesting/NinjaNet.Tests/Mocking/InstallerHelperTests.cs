using System;
using System.Net;
using Moq;
using TestNinja.Mocking;
using TestNinjaNet.Mocking;

namespace NinjaNet.Tests.Mocking
{
	public class InstallerHelperTests
	{
		private Mock<IFileDownloader> _fileDownloader;
		private InstallerHelper _installerHelper;

		[SetUp]
		public void SetUp()
		{
            _fileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_fileDownloader.Object);
        }

		[Test]
		public void DownloadInstaller_DownloadFails_ReturnFalse()
		{
			_fileDownloader.Setup(fq =>
			 fq.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
				.Throws<WebException>();
			var result = _installerHelper.DownloadInstaller("customer", "installer");
			Assert.That(result, Is.False);

        }
		[Test]
		public void DownloadIstaller_DownloadCompetes_ReturnTrue()
		{
			var result = _installerHelper.DownloadInstaller("customer", "installer");
			Assert.That(result, Is.True);
		}
	}
}

